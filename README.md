# Snappy
Snappy


1) First run this command to get RabbitMQ running on container

docker run --rm -it --hostname my-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management
rabbitmq user: guest
rabbitmq password: guest



2) Login via booking service and add that bearer token in swagger authorize.

3) Call booking api with 1 (its already booked).

4) Call booking api with carId 2 for full response.
