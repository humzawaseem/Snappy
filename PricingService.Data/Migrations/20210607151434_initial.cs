using Microsoft.EntityFrameworkCore.Migrations;

namespace PricingService.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    BasePrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BasePrice", "LicensePlate", "Make", "Model", "Year" },
                values: new object[] { 1, 30.0, "A1", "Honda", "City", "2020" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BasePrice", "LicensePlate", "Make", "Model", "Year" },
                values: new object[] { 2, 80.0, "A2", "Nissan", "GTR", "2008" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
