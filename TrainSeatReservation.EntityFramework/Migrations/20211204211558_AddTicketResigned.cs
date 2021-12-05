using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class AddTicketResigned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a66c7cb-f153-404a-b142-df11228d1fa5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab1d6d62-aec5-411d-bf3e-10bb6f7bfabf");

            migrationBuilder.CreateTable(
                name: "TicketsResigned",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TripDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTrainStationId = table.Column<int>(type: "int", nullable: false),
                    DepartureTrainStationId = table.Column<int>(type: "int", nullable: false),
                    ArrivalStationId = table.Column<int>(type: "int", nullable: false),
                    DepartureStationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketsResigned", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketsResigned_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketsResigned_Stations_ArrivalStationId",
                        column: x => x.ArrivalStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketsResigned_Stations_DepartureStationId",
                        column: x => x.DepartureStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketsResigned_TrainStations_ArrivalTrainStationId",
                        column: x => x.ArrivalTrainStationId,
                        principalTable: "TrainStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketsResigned_TrainStations_DepartureTrainStationId",
                        column: x => x.DepartureTrainStationId,
                        principalTable: "TrainStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16cff0e8-a7c6-4a7f-ae34-5e18425508ee", "419978b0-94c0-48da-a365-64c0063c8168", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "214406c5-d7d8-48d5-9a2a-d47db67daab7", "2a06e9f8-741f-4616-ab58-573be40bcba5", "Client", "CLIENT" });

            migrationBuilder.CreateIndex(
                name: "IX_TicketsResigned_ArrivalStationId",
                table: "TicketsResigned",
                column: "ArrivalStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsResigned_ArrivalTrainStationId",
                table: "TicketsResigned",
                column: "ArrivalTrainStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsResigned_DepartureStationId",
                table: "TicketsResigned",
                column: "DepartureStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsResigned_DepartureTrainStationId",
                table: "TicketsResigned",
                column: "DepartureTrainStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsResigned_UserId",
                table: "TicketsResigned",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketsResigned");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16cff0e8-a7c6-4a7f-ae34-5e18425508ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "214406c5-d7d8-48d5-9a2a-d47db67daab7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab1d6d62-aec5-411d-bf3e-10bb6f7bfabf", "a0a57870-4165-4a35-986c-dc676dad352e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a66c7cb-f153-404a-b142-df11228d1fa5", "eed1d417-8925-4b7b-90c7-a34031182774", "Client", "CLIENT" });
        }
    }
}
