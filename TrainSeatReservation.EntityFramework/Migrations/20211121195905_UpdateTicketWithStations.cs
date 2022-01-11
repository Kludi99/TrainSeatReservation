//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class UpdateTicketWithStations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cf69d14-bdbb-4fc3-8a46-676d6324fa6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdad6042-6008-4309-973d-9682a0135720");

            migrationBuilder.AddColumn<int>(
                name: "ArrivalStationId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartureStationId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2416903e-1bd4-41db-81b4-c9dfdf5814eb", "57224d6c-39ee-45fc-9f62-84858ac44c5a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "594e8a4e-5b00-4a24-856a-24168c4e7b88", "7b729659-71d8-45ba-8ebe-28c3e2f2525c", "Client", "CLIENT" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ArrivalStationId",
                table: "Tickets",
                column: "ArrivalStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DepartureStationId",
                table: "Tickets",
                column: "DepartureStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Stations_ArrivalStationId",
                table: "Tickets",
                column: "ArrivalStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Stations_DepartureStationId",
                table: "Tickets",
                column: "DepartureStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Stations_ArrivalStationId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Stations_DepartureStationId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ArrivalStationId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_DepartureStationId",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2416903e-1bd4-41db-81b4-c9dfdf5814eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "594e8a4e-5b00-4a24-856a-24168c4e7b88");

            migrationBuilder.DropColumn(
                name: "ArrivalStationId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DepartureStationId",
                table: "Tickets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cdad6042-6008-4309-973d-9682a0135720", "516245bc-0441-4897-81aa-b2189a6fb3be", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cf69d14-bdbb-4fc3-8a46-676d6324fa6c", "42f52426-d27c-42e5-a8c4-d18d26f1a1f5", "Client", "CLIENT" });
        }
    }
}
