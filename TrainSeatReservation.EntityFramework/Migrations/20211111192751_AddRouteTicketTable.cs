using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class AddRouteTicketTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b7fe95f-ac9b-4d49-b0fe-413f2d429c87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d466a767-7a6a-4e81-8206-91ae8d9f1801");

            migrationBuilder.CreateTable(
                name: "RouteTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    TripDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteTickets_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "611b0535-8de4-4f0c-b104-6e2d925b5ee5", "b50041fb-e125-4668-8cbe-4f5fd23b34c1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b069c573-4f85-4e2d-8222-bc5de44ed70b", "3716baf7-580d-4a11-89b7-18f88e21fbb5", "Client", "CLIENT" });

            migrationBuilder.CreateIndex(
                name: "IX_RouteTickets_RouteId",
                table: "RouteTickets",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteTickets_TicketId",
                table: "RouteTickets",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouteTickets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "611b0535-8de4-4f0c-b104-6e2d925b5ee5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b069c573-4f85-4e2d-8222-bc5de44ed70b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b7fe95f-ac9b-4d49-b0fe-413f2d429c87", "422cbdf3-fec8-449e-9145-8cd15a11a874", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d466a767-7a6a-4e81-8206-91ae8d9f1801", "9c4e21ec-fc95-4ac8-a8b6-028035bf8c7c", "Client", "CLIENT" });
        }
    }
}
