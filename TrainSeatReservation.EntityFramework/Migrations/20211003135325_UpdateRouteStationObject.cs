//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class UpdateRouteStationObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05687039-32b6-42a4-b671-12a1045c67b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "951c24e2-9686-4da1-84a3-6e45a6d1025d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "268aa8a9-e49e-4105-b57e-e94c9da84c66", "33101955-65ef-417d-a69d-2ab8d9b5f4ea", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d863e41c-01ac-454d-8bda-93a845635c0f", "bd2d0c56-9306-4ee0-a492-3e95d947d0c7", "Client", "CLIENT" });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 56,
                column: "EndStationId",
                value: 48);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "268aa8a9-e49e-4105-b57e-e94c9da84c66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d863e41c-01ac-454d-8bda-93a845635c0f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "951c24e2-9686-4da1-84a3-6e45a6d1025d", "d232ac5e-874e-4732-bda5-ed2605997151", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05687039-32b6-42a4-b671-12a1045c67b9", "36d7e1f6-b0b2-4d90-a81e-bf9ea6930c82", "Client", "CLIENT" });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 56,
                column: "EndStationId",
                value: 37);
        }
    }
}
