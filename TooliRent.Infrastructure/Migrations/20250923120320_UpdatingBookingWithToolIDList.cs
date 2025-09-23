using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TooliRent.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingBookingWithToolIDList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tools_ToolId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ToolId",
                table: "Bookings");

            migrationBuilder.AlterColumn<string>(
                name: "ToolId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "BookingTool",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    ToolsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTool", x => new { x.BookingsId, x.ToolsId });
                    table.ForeignKey(
                        name: "FK_BookingTool_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingTool_Tools_ToolsId",
                        column: x => x.ToolsId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                column: "ToolId",
                value: "[1]");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ToolId",
                value: "[2]");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTool_ToolsId",
                table: "BookingTool",
                column: "ToolsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingTool");

            migrationBuilder.AlterColumn<int>(
                name: "ToolId",
                table: "Bookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                column: "ToolId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ToolId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ToolId",
                table: "Bookings",
                column: "ToolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tools_ToolId",
                table: "Bookings",
                column: "ToolId",
                principalTable: "Tools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
