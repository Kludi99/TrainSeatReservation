using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class UpdateRouteStationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "529dceac-6723-49fb-abc2-39e07a5c9e11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73da2838-2a08-446f-b247-dd8100cca7f9");

            migrationBuilder.AddColumn<int>(
                name: "EndTrainTimeTableId",
                table: "RouteStations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartTrainTimeTableId",
                table: "RouteStations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainId",
                table: "RouteStations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fda56c0a-e636-4deb-9de5-31a7a167563d", "635a7283-91e7-445d-ae59-5e7dfcf512fd", "Admin", "ADMIN" },
                    { "97c3b491-5556-4c8b-a388-31aac1a8b2cb", "0476baf6-b8ed-4b0c-b693-cb4e0a341df1", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 2, 1, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 3, 2, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 4, 3, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 5, 4, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 6, 5, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 7, 6, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 8, 7, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 9, 8, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 10, 9, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 11, 10, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 12, 11, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 13, 12, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 14, 13, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 15, 14, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 16, 15, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 17, 16, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 18, 17, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 19, 18, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 20, 19, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 21, 20, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 22, 21, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 23, 22, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 24, 23, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 25, 24, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 26, 25, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 27, 26, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 28, 27, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 29, 28, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 30, 29, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 31, 30, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 32, 31, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 33, 32, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 34, 33, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 35, 34, 1 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 37, 36, 2 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 38, 37, 2 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 39, 38, 2 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 40, 39, 2 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 41, 40, 2 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 42, 41, 2 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 43, 42, 2 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 44, 43, 2 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 45, 44, 2 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 46, 45, 2 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 47, 46, 2 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 48, 47, 2 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 49, 48, 2 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 50, 49, 2 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 52, 51, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 53, 52, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 54, 53, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 55, 54, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 56, 55, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 57, 56, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 58, 57, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 59, 58, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 60, 59, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 61, 60, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 62, 61, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 63, 62, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 64, 63, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 65, 64, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 66, 65, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 67, 66, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 68, 67, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 69, 68, 3 });

            migrationBuilder.UpdateData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "EndTrainTimeTableId", "StartTrainTimeTableId", "TrainId" },
                values: new object[] { 70, 69, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_RouteStations_EndTrainTimeTableId",
                table: "RouteStations",
                column: "EndTrainTimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteStations_StartTrainTimeTableId",
                table: "RouteStations",
                column: "StartTrainTimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteStations_TrainId",
                table: "RouteStations",
                column: "TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStations_Trains_TrainId",
                table: "RouteStations",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStations_TrainTimeTables_EndTrainTimeTableId",
                table: "RouteStations",
                column: "EndTrainTimeTableId",
                principalTable: "TrainTimeTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStations_TrainTimeTables_StartTrainTimeTableId",
                table: "RouteStations",
                column: "StartTrainTimeTableId",
                principalTable: "TrainTimeTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteStations_Trains_TrainId",
                table: "RouteStations");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteStations_TrainTimeTables_EndTrainTimeTableId",
                table: "RouteStations");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteStations_TrainTimeTables_StartTrainTimeTableId",
                table: "RouteStations");

            migrationBuilder.DropIndex(
                name: "IX_RouteStations_EndTrainTimeTableId",
                table: "RouteStations");

            migrationBuilder.DropIndex(
                name: "IX_RouteStations_StartTrainTimeTableId",
                table: "RouteStations");

            migrationBuilder.DropIndex(
                name: "IX_RouteStations_TrainId",
                table: "RouteStations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97c3b491-5556-4c8b-a388-31aac1a8b2cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fda56c0a-e636-4deb-9de5-31a7a167563d");

            migrationBuilder.DropColumn(
                name: "EndTrainTimeTableId",
                table: "RouteStations");

            migrationBuilder.DropColumn(
                name: "StartTrainTimeTableId",
                table: "RouteStations");

            migrationBuilder.DropColumn(
                name: "TrainId",
                table: "RouteStations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73da2838-2a08-446f-b247-dd8100cca7f9", "1aba5b35-2b10-4e83-b35e-2423d2086b2b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "529dceac-6723-49fb-abc2-39e07a5c9e11", "62caf9fc-1e19-47d5-96a8-ce96691e4acd", "Client", "CLIENT" });
        }
    }
}
