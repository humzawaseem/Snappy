using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PricingService.Data.DBContext;
using PricingService.Data.Models;
using PricingService.Data.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ConsumerMQ
{
    class Program
    {
        private readonly ICarService _carService;
        public Program(ICarService carService)
        {
            _carService = carService;
        }

        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<PricingContext>(options =>
                {
                    options.UseSqlServer("Server=.;Database=SnappCarPricingDb;Trusted_Connection=True;MultipleActiveResultSets=true");
                })
                .AddTransient<ICarService, CarService>()
                .BuildServiceProvider();

            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
           
            channel.QueueDeclare(queue: "rpc_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(queue: "rpc_queue", autoAck: false, consumer: consumer);
            Console.WriteLine(" [x] Awaiting RPC requests");
            consumer.Received += (model, ea) =>
            {
                string response = null;
                var result = new CarPricingModel();
                var body = ea.Body.ToArray();
                var props = ea.BasicProperties;
                var replyProps = channel.CreateBasicProperties();
                replyProps.CorrelationId = props.CorrelationId;

                try
                {
                    var message = Encoding.UTF8.GetString(body);
                    var dto = JsonConvert.DeserializeObject<GetPricingModel>(message);
                    var service = (ICarService)serviceProvider.GetService(typeof(ICarService));
                    result = service.CheckPricing(dto.CarId, dto.StartTime, dto.EndTime).GetAwaiter().GetResult();

                }
                catch (Exception e)
                {
                    Console.WriteLine(" [.] " + e.Message);
                    response = "";
                }
                finally
                {
                    var responseBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result));
                    channel.BasicPublish(exchange: "", routingKey: props.ReplyTo,
                        basicProperties: replyProps, body: responseBytes);
                    channel.BasicAck(deliveryTag: ea.DeliveryTag,
                        multiple: false);
                }
            };

            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
