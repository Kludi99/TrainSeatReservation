//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class AddRouteToTrainStationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrainStations_TrainId_StationId_TrainTimeTableId",
                table: "TrainStations");

            migrationBuilder.DropIndex(
                name: "IX_Routes_TrainId",
                table: "Routes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1908a05-673c-41c1-a210-5e5a2e5ab4f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d26f87a6-3580-434e-ac4e-0ffbc7babc70");

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "TrainStations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "951c24e2-9686-4da1-84a3-6e45a6d1025d", "d232ac5e-874e-4732-bda5-ed2605997151", "Admin", "ADMIN" },
                    { "05687039-32b6-42a4-b671-12a1045c67b9", "36d7e1f6-b0b2-4d90-a81e-bf9ea6930c82", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 13,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 14,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 15,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 16,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 17,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 18,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 19,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 20,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 21,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 22,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 23,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 24,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 25,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 26,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 27,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 28,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 29,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 30,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 31,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 32,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 33,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 34,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 35,
                column: "RouteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 36,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 37,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 38,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 39,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 40,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 41,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 42,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 43,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 44,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 45,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 46,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 47,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 48,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 49,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 50,
                column: "RouteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 51,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 52,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 53,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 54,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 55,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 56,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 57,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 58,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 59,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 60,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 61,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 62,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 63,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 64,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 65,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 66,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 67,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 68,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 69,
                column: "RouteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 70,
                column: "RouteId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_TrainStations_RouteId",
                table: "TrainStations",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainStations_TrainId_StationId_TrainTimeTableId_RouteId",
                table: "TrainStations",
                columns: new[] { "TrainId", "StationId", "TrainTimeTableId", "RouteId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_TrainId",
                table: "Routes",
                column: "TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainStations_Routes_RouteId",
                table: "TrainStations",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainStations_Routes_RouteId",
                table: "TrainStations");

            migrationBuilder.DropIndex(
                name: "IX_TrainStations_RouteId",
                table: "TrainStations");

            migrationBuilder.DropIndex(
                name: "IX_TrainStations_TrainId_StationId_TrainTimeTableId_RouteId",
                table: "TrainStations");

            migrationBuilder.DropIndex(
                name: "IX_Routes_TrainId",
                table: "Routes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05687039-32b6-42a4-b671-12a1045c67b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "951c24e2-9686-4da1-84a3-6e45a6d1025d");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "TrainStations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1908a05-673c-41c1-a210-5e5a2e5ab4f8", "ed8494d0-79e9-4ead-835d-fb8e79700a7b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d26f87a6-3580-434e-ac4e-0ffbc7babc70", "5b119b17-f9e4-4a51-9abd-3cc6e8f65679", "Client", "CLIENT" });

            migrationBuilder.CreateIndex(
                name: "IX_TrainStations_TrainId_StationId_TrainTimeTableId",
                table: "TrainStations",
                columns: new[] { "TrainId", "StationId", "TrainTimeTableId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_TrainId",
                table: "Routes",
                column: "TrainId",
                unique: true);
        }
    }
}
