using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShoppingApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "DiscountPercentage", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 27, 11, 21, 10, 351, DateTimeKind.Local).AddTicks(3935), "Gaming Laptop", 10m, "Laptop", 60000m },
                    { 2, new DateTime(2026, 2, 27, 11, 21, 10, 351, DateTimeKind.Local).AddTicks(3954), "Smart Phone", 5m, "Mobile", 20000m },
                    { 3, new DateTime(2026, 2, 27, 11, 21, 10, 351, DateTimeKind.Local).AddTicks(3956), "Noise Cancelling", 15m, "Headphones", 5000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
