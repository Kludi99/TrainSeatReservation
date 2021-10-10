using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class UpdateDistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { "73da2838-2a08-446f-b247-dd8100cca7f9", "1aba5b35-2b10-4e83-b35e-2423d2086b2b", "Admin", "ADMIN" },
                    { "529dceac-6723-49fb-abc2-39e07a5c9e11", "62caf9fc-1e19-47d5-96a8-ce96691e4acd", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 43,
                column: "Distance",
                value: 20);

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 44,
                column: "Distance",
                value: 17);

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 58,
                column: "Distance",
                value: 20);

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 59,
                column: "Distance",
                value: 17);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "529dceac-6723-49fb-abc2-39e07a5c9e11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73da2838-2a08-446f-b247-dd8100cca7f9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "268aa8a9-e49e-4105-b57e-e94c9da84c66", "33101955-65ef-417d-a69d-2ab8d9b5f4ea", "Admin", "ADMIN" },
                    { "d863e41c-01ac-454d-8bda-93a845635c0f", "bd2d0c56-9306-4ee0-a492-3e95d947d0c7", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 43,
                column: "Distance",
                value: 36);

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 44,
                column: "Distance",
                value: 20);

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 58,
                column: "Distance",
                value: 23);

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 59,
                column: "Distance",
                value: 23);
        }
    }
}
