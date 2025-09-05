using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TooliRent.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Electric and battery-powered tools", "Power Tools" },
                    { 2, "Manual tools for various tasks", "Hand Tools" }
                });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "Available", "CategoryId", "Description", "ToolType" },
                values: new object[,]
                {
                    { 1, true, 1, "18V cordless drill with battery", "Cordless Drill" },
                    { 2, true, 2, "16oz claw hammer", "Hammer" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CreatedDate", "IsPickedUp", "ReturnDate", "ToolId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1, "admin" },
                    { 2, new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
