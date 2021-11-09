using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class AddSeatTicketTableAndSomeFlags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Tickets_TicketId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_TicketId",
                table: "Seats");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82d51edf-38bf-4859-801b-0f72f088caeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c098558f-4dbe-470f-905e-e0903da764a9");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Seats");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BicyclePlace",
                table: "Carriages",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CateringCar",
                table: "Carriages",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EletricalOutlet",
                table: "Carriages",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SeatTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatTickets_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa6f7c6b-a5d7-4a8a-bc0d-00d4ab8d1603", "1d0ab432-7e03-4e8d-b002-1a443e8179d4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15e0241d-914f-4099-9633-bd383274588e", "f36fab1a-71d5-4b9c-b752-26b64871a563", "Client", "CLIENT" });

            migrationBuilder.CreateIndex(
                name: "IX_SeatTickets_SeatId",
                table: "SeatTickets",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatTickets_TicketId",
                table: "SeatTickets",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatTickets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15e0241d-914f-4099-9633-bd383274588e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa6f7c6b-a5d7-4a8a-bc0d-00d4ab8d1603");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "BicyclePlace",
                table: "Carriages");

            migrationBuilder.DropColumn(
                name: "CateringCar",
                table: "Carriages");

            migrationBuilder.DropColumn(
                name: "EletricalOutlet",
                table: "Carriages");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82d51edf-38bf-4859-801b-0f72f088caeb", "0f5fa290-0339-41de-9d92-9713399bfaee", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c098558f-4dbe-470f-905e-e0903da764a9", "8737103e-9429-4156-a723-f73ff5044cd1", "Client", "CLIENT" });

            migrationBuilder.CreateIndex(
                name: "IX_Seats_TicketId",
                table: "Seats",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Tickets_TicketId",
                table: "Seats",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
