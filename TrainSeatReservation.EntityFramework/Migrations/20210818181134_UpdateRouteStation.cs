//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class UpdateRouteStation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteStation_Station_StationId",
                table: "RouteStation");

            migrationBuilder.DropIndex(
                name: "IX_RouteStation_RouteId_StationId",
                table: "RouteStation");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Route");

            migrationBuilder.RenameColumn(
                name: "StationId",
                table: "RouteStation",
                newName: "StartStationId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteStation_StationId",
                table: "RouteStation",
                newName: "IX_RouteStation_StartStationId");

            migrationBuilder.AddColumn<int>(
                name: "Distance",
                table: "RouteStation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndStationId",
                table: "RouteStation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "RouteStation",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_RouteStation_EndStationId",
                table: "RouteStation",
                column: "EndStationId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteStation_RouteId_StartStationId_EndStationId",
                table: "RouteStation",
                columns: new[] { "RouteId", "StartStationId", "EndStationId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStation_Station_EndStationId",
                table: "RouteStation",
                column: "EndStationId",
                principalTable: "Station",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStation_Station_StartStationId",
                table: "RouteStation",
                column: "StartStationId",
                principalTable: "Station",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteStation_Station_EndStationId",
                table: "RouteStation");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteStation_Station_StartStationId",
                table: "RouteStation");

            migrationBuilder.DropIndex(
                name: "IX_RouteStation_EndStationId",
                table: "RouteStation");

            migrationBuilder.DropIndex(
                name: "IX_RouteStation_RouteId_StartStationId_EndStationId",
                table: "RouteStation");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "RouteStation");

            migrationBuilder.DropColumn(
                name: "EndStationId",
                table: "RouteStation");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "RouteStation");

            migrationBuilder.RenameColumn(
                name: "StartStationId",
                table: "RouteStation",
                newName: "StationId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteStation_StartStationId",
                table: "RouteStation",
                newName: "IX_RouteStation_StationId");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Route",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_RouteStation_RouteId_StationId",
                table: "RouteStation",
                columns: new[] { "RouteId", "StationId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStation_Station_StationId",
                table: "RouteStation",
                column: "StationId",
                principalTable: "Station",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
