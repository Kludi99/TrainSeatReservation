using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class AddTicketChangeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2416903e-1bd4-41db-81b4-c9dfdf5814eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "594e8a4e-5b00-4a24-856a-24168c4e7b88");

            migrationBuilder.CreateTable(
                name: "TicketChanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    TransitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketChanges_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketChanges_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab1d6d62-aec5-411d-bf3e-10bb6f7bfabf", "a0a57870-4165-4a35-986c-dc676dad352e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a66c7cb-f153-404a-b142-df11228d1fa5", "eed1d417-8925-4b7b-90c7-a34031182774", "Client", "CLIENT" });

            migrationBuilder.CreateIndex(
                name: "IX_TicketChanges_StationId",
                table: "TicketChanges",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketChanges_TicketId",
                table: "TicketChanges",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketChanges");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a66c7cb-f153-404a-b142-df11228d1fa5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab1d6d62-aec5-411d-bf3e-10bb6f7bfabf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2416903e-1bd4-41db-81b4-c9dfdf5814eb", "57224d6c-39ee-45fc-9f62-84858ac44c5a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "594e8a4e-5b00-4a24-856a-24168c4e7b88", "7b729659-71d8-45ba-8ebe-28c3e2f2525c", "Client", "CLIENT" });
        }
    }
}
