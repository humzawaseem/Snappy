using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingService.Data.Migrations
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

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingStart = table.Column<DateTime>(nullable: false),
                    BookingEnd = table.Column<DateTime>(nullable: false),
                    Payment = table.Column<double>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BasePrice", "LicensePlate", "Make", "Model", "Year" },
                values: new object[] { 1, 30.0, "A1", "Honda", "City", "2020" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BasePrice", "LicensePlate", "Make", "Model", "Year" },
                values: new object[] { 2, 80.0, "A2", "Nissan", "GTR", "2008" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingEnd", "BookingStart", "CarId", "IsCompleted", "Payment" },
                values: new object[] { 1, new DateTime(2021, 6, 9, 20, 15, 32, 67, DateTimeKind.Local).AddTicks(9052), new DateTime(2021, 6, 7, 20, 15, 32, 68, DateTimeKind.Local).AddTicks(7100), 1, false, 75.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CarId",
                table: "Bookings",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
