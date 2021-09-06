using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class CreateIndexesAddTrainTimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteStation_Routes_RouteId",
                table: "RouteStation");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteStation_Stations_EndStationId",
                table: "RouteStation");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteStation_Stations_StartStationId",
                table: "RouteStation");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Carriages_CarriageId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_DictionaryItems_SeatTypeId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDiscount_Discounts_DiscountId",
                table: "TicketDiscount");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDiscount_Tickets_TicketId",
                table: "TicketDiscount");

            migrationBuilder.DropForeignKey(
                name: "FK_Train_DictionaryItems_TypeId",
                table: "Train");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainCarriage_Carriages_CarriageId",
                table: "TrainCarriage");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainCarriage_Train_TrainId",
                table: "TrainCarriage");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStations_Train_TrainId",
                table: "TrainStations");

            migrationBuilder.DropIndex(
                name: "IX_TrainStations_TrainId",
                table: "TrainStations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainCarriage",
                table: "TrainCarriage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Train",
                table: "Train");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketDiscount",
                table: "TicketDiscount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RouteStation",
                table: "RouteStation");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "078f51a5-97fa-498c-965a-79ec3a6fade1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc95084f-de39-4a1a-a6f8-926a5d53bf8e");

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "TrainStations");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "TrainStations");

            migrationBuilder.RenameTable(
                name: "TrainCarriage",
                newName: "TrainCarriages");

            migrationBuilder.RenameTable(
                name: "Train",
                newName: "Trains");

            migrationBuilder.RenameTable(
                name: "TicketDiscount",
                newName: "TicketDiscounts");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameTable(
                name: "RouteStation",
                newName: "RouteStations");

            migrationBuilder.RenameIndex(
                name: "IX_TrainCarriage_TrainId",
                table: "TrainCarriages",
                newName: "IX_TrainCarriages_TrainId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainCarriage_CarriageId",
                table: "TrainCarriages",
                newName: "IX_TrainCarriages_CarriageId");

            migrationBuilder.RenameIndex(
                name: "IX_Train_TypeId",
                table: "Trains",
                newName: "IX_Trains_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Train_Number",
                table: "Trains",
                newName: "IX_Trains_Number");

            migrationBuilder.RenameIndex(
                name: "IX_TicketDiscount_TicketId",
                table: "TicketDiscounts",
                newName: "IX_TicketDiscounts_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketDiscount_DiscountId",
                table: "TicketDiscounts",
                newName: "IX_TicketDiscounts_DiscountId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_SeatTypeId",
                table: "Seats",
                newName: "IX_Seats_SeatTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_CarriageId",
                table: "Seats",
                newName: "IX_Seats_CarriageId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteStation_StartStationId",
                table: "RouteStations",
                newName: "IX_RouteStations_StartStationId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteStation_RouteId_StartStationId_EndStationId",
                table: "RouteStations",
                newName: "IX_RouteStations_RouteId_StartStationId_EndStationId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteStation_EndStationId",
                table: "RouteStations",
                newName: "IX_RouteStations_EndStationId");

            migrationBuilder.AddColumn<int>(
                name: "TrainTimeTableId",
                table: "TrainStations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainCarriages",
                table: "TrainCarriages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trains",
                table: "Trains",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketDiscounts",
                table: "TicketDiscounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouteStations",
                table: "RouteStations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TrainTimeTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    DepartureTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    StartingDateOfTimeTable = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainTimeTables", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d365021b-8ff2-49ab-83e6-976debfca6a8", "45cc1693-0ea6-473a-8a4e-2f6c2b91f53f", "Admin", "ADMIN" },
                    { "023e8964-0220-4bc2-9e1e-ab6e6c5f1c81", "0ba7d32b-c727-4c91-889e-3704669fdf47", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "TrainTimeTables",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "StartingDateOfTimeTable" },
                values: new object[,]
                {
                    { 27, new TimeSpan(0, 21, 35, 0, 0), new TimeSpan(0, 21, 36, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new TimeSpan(0, 21, 57, 0, 0), new TimeSpan(0, 22, 59, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new TimeSpan(0, 22, 23, 0, 0), new TimeSpan(0, 22, 24, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, new TimeSpan(0, 22, 36, 0, 0), new TimeSpan(0, 22, 37, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, new TimeSpan(0, 22, 44, 0, 0), new TimeSpan(0, 22, 45, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, new TimeSpan(0, 22, 53, 0, 0), new TimeSpan(0, 22, 54, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, new TimeSpan(0, 23, 1, 0, 0), new TimeSpan(0, 23, 2, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, new TimeSpan(0, 23, 33, 0, 0), new TimeSpan(0, 23, 34, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, new TimeSpan(0, 23, 56, 0, 0), new TimeSpan(0, 23, 59, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, new TimeSpan(0, 17, 32, 0, 0), new TimeSpan(0, 17, 58, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, new TimeSpan(0, 18, 18, 0, 0), new TimeSpan(0, 18, 19, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, new TimeSpan(0, 18, 38, 0, 0), new TimeSpan(0, 18, 39, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, new TimeSpan(0, 18, 55, 0, 0), new TimeSpan(0, 18, 56, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, new TimeSpan(0, 19, 13, 0, 0), new TimeSpan(0, 19, 14, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, new TimeSpan(0, 19, 30, 0, 0), new TimeSpan(0, 19, 31, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, new TimeSpan(0, 19, 43, 0, 0), new TimeSpan(0, 19, 44, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, new TimeSpan(0, 19, 54, 0, 0), new TimeSpan(0, 19, 55, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, new TimeSpan(0, 20, 17, 0, 0), new TimeSpan(0, 20, 19, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, new TimeSpan(0, 20, 25, 0, 0), new TimeSpan(0, 20, 44, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, new TimeSpan(0, 20, 48, 0, 0), new TimeSpan(0, 20, 49, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, new TimeSpan(0, 21, 58, 0, 0), new TimeSpan(0, 21, 59, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, new TimeSpan(0, 22, 31, 0, 0), new TimeSpan(0, 22, 32, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new TimeSpan(0, 21, 3, 0, 0), new TimeSpan(0, 21, 26, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new TimeSpan(0, 20, 38, 0, 0), new TimeSpan(0, 20, 39, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new TimeSpan(0, 20, 29, 0, 0), new TimeSpan(0, 20, 30, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new TimeSpan(0, 20, 6, 0, 0), new TimeSpan(0, 20, 9, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, null, new TimeSpan(0, 13, 41, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 14, 1, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new TimeSpan(0, 14, 4, 0, 0), new TimeSpan(0, 14, 5, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new TimeSpan(0, 14, 8, 0, 0), new TimeSpan(0, 14, 9, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new TimeSpan(0, 14, 13, 0, 0), new TimeSpan(0, 14, 13, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new TimeSpan(0, 14, 17, 0, 0), new TimeSpan(0, 14, 18, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new TimeSpan(0, 14, 21, 0, 0), new TimeSpan(0, 14, 21, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new TimeSpan(0, 14, 26, 0, 0), new TimeSpan(0, 14, 27, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new TimeSpan(0, 14, 42, 0, 0), new TimeSpan(0, 14, 43, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 15, 1, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, new TimeSpan(0, 23, 10, 0, 0), new TimeSpan(0, 23, 11, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new TimeSpan(0, 15, 17, 0, 0), new TimeSpan(0, 15, 18, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new TimeSpan(0, 15, 39, 0, 0), new TimeSpan(0, 15, 40, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 16, 7, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TrainTimeTables",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "StartingDateOfTimeTable" },
                values: new object[,]
                {
                    { 15, new TimeSpan(0, 16, 13, 0, 0), new TimeSpan(0, 16, 29, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new TimeSpan(0, 16, 34, 0, 0), new TimeSpan(0, 16, 36, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 17, 31, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new TimeSpan(0, 17, 54, 0, 0), new TimeSpan(0, 17, 55, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new TimeSpan(0, 18, 21, 0, 0), new TimeSpan(0, 18, 22, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new TimeSpan(0, 18, 46, 0, 0), new TimeSpan(0, 18, 50, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new TimeSpan(0, 18, 54, 0, 0), new TimeSpan(0, 18, 57, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new TimeSpan(0, 19, 23, 0, 0), new TimeSpan(0, 19, 35, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new TimeSpan(0, 15, 29, 0, 0), new TimeSpan(0, 15, 30, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, new TimeSpan(0, 23, 48, 0, 0), new TimeSpan(0, 23, 57, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "TrainTimeTableId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "TrainTimeTableId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "TrainTimeTableId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "TrainTimeTableId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "TrainTimeTableId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "TrainTimeTableId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "TrainTimeTableId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 8,
                column: "TrainTimeTableId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 9,
                column: "TrainTimeTableId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 10,
                column: "TrainTimeTableId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 11,
                column: "TrainTimeTableId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 12,
                column: "TrainTimeTableId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 13,
                column: "TrainTimeTableId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 14,
                column: "TrainTimeTableId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 15,
                column: "TrainTimeTableId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 16,
                column: "TrainTimeTableId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 17,
                column: "TrainTimeTableId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 18,
                column: "TrainTimeTableId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 19,
                column: "TrainTimeTableId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 21, 21 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 22, 22 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 23, 23 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 24, 24 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 25, 25 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 26, 26 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 27, 27 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 28, 28 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 29, 29 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 30, 30 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 31, 31 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 32, 32 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 33, 33 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 34, 34 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 35, 35 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "StationId", "TrainId", "TrainTimeTableId" },
                values: new object[] { 1, 2, 36 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 2, 37 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 8, 38 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 9, 39 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 10, 40 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 11, 41 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 12, 42 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 13, 43 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 14, 44 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 15, 45 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 16, 46 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 36, 47 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 37, 48 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 38, 49 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "StationId", "TrainTimeTableId" },
                values: new object[] { 39, 50 });

            migrationBuilder.InsertData(
                table: "TrainStations",
                columns: new[] { "Id", "StationId", "TrainId", "TrainTimeTableId" },
                values: new object[] { 20, 20, 1, 20 });

            migrationBuilder.CreateIndex(
                name: "IX_TrainStations_TrainId_StationId_TrainTimeTableId",
                table: "TrainStations",
                columns: new[] { "TrainId", "StationId", "TrainTimeTableId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainStations_TrainTimeTableId",
                table: "TrainStations",
                column: "TrainTimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_Name",
                table: "Stations",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTimeTables_ArrivalTime_DepartureTime_StartingDateOfTimeTable",
                table: "TrainTimeTables",
                columns: new[] { "ArrivalTime", "DepartureTime", "StartingDateOfTimeTable" },
                unique: true,
                filter: "[ArrivalTime] IS NOT NULL AND [DepartureTime] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStations_Routes_RouteId",
                table: "RouteStations",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStations_Stations_EndStationId",
                table: "RouteStations",
                column: "EndStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStations_Stations_StartStationId",
                table: "RouteStations",
                column: "StartStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Carriages_CarriageId",
                table: "Seats",
                column: "CarriageId",
                principalTable: "Carriages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_DictionaryItems_SeatTypeId",
                table: "Seats",
                column: "SeatTypeId",
                principalTable: "DictionaryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDiscounts_Discounts_DiscountId",
                table: "TicketDiscounts",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDiscounts_Tickets_TicketId",
                table: "TicketDiscounts",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainCarriages_Carriages_CarriageId",
                table: "TrainCarriages",
                column: "CarriageId",
                principalTable: "Carriages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainCarriages_Trains_TrainId",
                table: "TrainCarriages",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trains_DictionaryItems_TypeId",
                table: "Trains",
                column: "TypeId",
                principalTable: "DictionaryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainStations_Trains_TrainId",
                table: "TrainStations",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainStations_TrainTimeTables_TrainTimeTableId",
                table: "TrainStations",
                column: "TrainTimeTableId",
                principalTable: "TrainTimeTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteStations_Routes_RouteId",
                table: "RouteStations");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteStations_Stations_EndStationId",
                table: "RouteStations");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteStations_Stations_StartStationId",
                table: "RouteStations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Carriages_CarriageId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_DictionaryItems_SeatTypeId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDiscounts_Discounts_DiscountId",
                table: "TicketDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDiscounts_Tickets_TicketId",
                table: "TicketDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainCarriages_Carriages_CarriageId",
                table: "TrainCarriages");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainCarriages_Trains_TrainId",
                table: "TrainCarriages");

            migrationBuilder.DropForeignKey(
                name: "FK_Trains_DictionaryItems_TypeId",
                table: "Trains");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStations_Trains_TrainId",
                table: "TrainStations");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStations_TrainTimeTables_TrainTimeTableId",
                table: "TrainStations");

            migrationBuilder.DropTable(
                name: "TrainTimeTables");

            migrationBuilder.DropIndex(
                name: "IX_TrainStations_TrainId_StationId_TrainTimeTableId",
                table: "TrainStations");

            migrationBuilder.DropIndex(
                name: "IX_TrainStations_TrainTimeTableId",
                table: "TrainStations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_Name",
                table: "Stations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trains",
                table: "Trains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainCarriages",
                table: "TrainCarriages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketDiscounts",
                table: "TicketDiscounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RouteStations",
                table: "RouteStations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "023e8964-0220-4bc2-9e1e-ab6e6c5f1c81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d365021b-8ff2-49ab-83e6-976debfca6a8");

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DropColumn(
                name: "TrainTimeTableId",
                table: "TrainStations");

            migrationBuilder.RenameTable(
                name: "Trains",
                newName: "Train");

            migrationBuilder.RenameTable(
                name: "TrainCarriages",
                newName: "TrainCarriage");

            migrationBuilder.RenameTable(
                name: "TicketDiscounts",
                newName: "TicketDiscount");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameTable(
                name: "RouteStations",
                newName: "RouteStation");

            migrationBuilder.RenameIndex(
                name: "IX_Trains_TypeId",
                table: "Train",
                newName: "IX_Train_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Trains_Number",
                table: "Train",
                newName: "IX_Train_Number");

            migrationBuilder.RenameIndex(
                name: "IX_TrainCarriages_TrainId",
                table: "TrainCarriage",
                newName: "IX_TrainCarriage_TrainId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainCarriages_CarriageId",
                table: "TrainCarriage",
                newName: "IX_TrainCarriage_CarriageId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketDiscounts_TicketId",
                table: "TicketDiscount",
                newName: "IX_TicketDiscount_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketDiscounts_DiscountId",
                table: "TicketDiscount",
                newName: "IX_TicketDiscount_DiscountId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_SeatTypeId",
                table: "Seat",
                newName: "IX_Seat_SeatTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_CarriageId",
                table: "Seat",
                newName: "IX_Seat_CarriageId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteStations_StartStationId",
                table: "RouteStation",
                newName: "IX_RouteStation_StartStationId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteStations_RouteId_StartStationId_EndStationId",
                table: "RouteStation",
                newName: "IX_RouteStation_RouteId_StartStationId_EndStationId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteStations_EndStationId",
                table: "RouteStation",
                newName: "IX_RouteStation_EndStationId");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "TrainStations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "TrainStations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Train",
                table: "Train",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainCarriage",
                table: "TrainCarriage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketDiscount",
                table: "TicketDiscount",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouteStation",
                table: "RouteStation",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "078f51a5-97fa-498c-965a-79ec3a6fade1", "39aa0251-0995-4c66-b198-f86368c422bb", "Admin", "ADMIN" },
                    { "fc95084f-de39-4a1a-a6f8-926a5d53bf8e", "a8c21a36-87e6-4f03-bb47-adcb8678e299", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 13, 41, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 1, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 14, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 5, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 14, 8, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 9, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 14, 13, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 13, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 14, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 14, 21, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 21, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 14, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 27, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 14, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 43, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 15, 1, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 15, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 15, 29, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 15, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 15, 39, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 15, 40, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 16, 7, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 16, 13, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 16, 29, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 16, 34, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 16, 36, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 17, 31, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 17, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 17, 55, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ArrivalDate", "DepartureDate" },
                values: new object[] { new DateTime(2020, 10, 10, 18, 21, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 18, 22, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 18, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 18, 50, 0, 0, DateTimeKind.Unspecified), 20 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 18, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 18, 57, 0, 0, DateTimeKind.Unspecified), 21 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 19, 23, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 19, 35, 0, 0, DateTimeKind.Unspecified), 22 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 20, 6, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 20, 9, 0, 0, DateTimeKind.Unspecified), 23 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 20, 29, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 20, 30, 0, 0, DateTimeKind.Unspecified), 24 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 20, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 20, 39, 0, 0, DateTimeKind.Unspecified), 25 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 21, 3, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 21, 26, 0, 0, DateTimeKind.Unspecified), 26 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 21, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 21, 36, 0, 0, DateTimeKind.Unspecified), 27 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 21, 57, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 22, 59, 0, 0, DateTimeKind.Unspecified), 28 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 22, 23, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 22, 24, 0, 0, DateTimeKind.Unspecified), 29 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 22, 36, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 22, 37, 0, 0, DateTimeKind.Unspecified), 30 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 22, 44, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 22, 45, 0, 0, DateTimeKind.Unspecified), 31 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 22, 53, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 22, 54, 0, 0, DateTimeKind.Unspecified), 32 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 23, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 23, 2, 0, 0, DateTimeKind.Unspecified), 33 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 23, 33, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 23, 34, 0, 0, DateTimeKind.Unspecified), 34 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId", "TrainId" },
                values: new object[] { new DateTime(2020, 10, 10, 23, 56, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 23, 59, 0, 0, DateTimeKind.Unspecified), 35, 1 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 17, 32, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 17, 58, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 18, 18, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 18, 19, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 18, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 18, 39, 0, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 18, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 18, 56, 0, 0, DateTimeKind.Unspecified), 9 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 19, 13, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 19, 14, 0, 0, DateTimeKind.Unspecified), 10 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 19, 31, 0, 0, DateTimeKind.Unspecified), 11 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 19, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 19, 44, 0, 0, DateTimeKind.Unspecified), 12 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 19, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 19, 55, 0, 0, DateTimeKind.Unspecified), 13 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 20, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 20, 19, 0, 0, DateTimeKind.Unspecified), 14 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 20, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 20, 44, 0, 0, DateTimeKind.Unspecified), 15 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 20, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 20, 49, 0, 0, DateTimeKind.Unspecified), 16 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 21, 58, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 21, 59, 0, 0, DateTimeKind.Unspecified), 36 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 22, 31, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 22, 32, 0, 0, DateTimeKind.Unspecified), 37 });

            migrationBuilder.UpdateData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ArrivalDate", "DepartureDate", "StationId" },
                values: new object[] { new DateTime(2020, 10, 10, 23, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 23, 11, 0, 0, DateTimeKind.Unspecified), 38 });

            migrationBuilder.InsertData(
                table: "TrainStations",
                columns: new[] { "Id", "ArrivalDate", "DepartureDate", "StationId", "TrainId" },
                values: new object[] { 51, new DateTime(2020, 10, 10, 23, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 23, 57, 0, 0, DateTimeKind.Unspecified), 39, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_TrainStations_TrainId",
                table: "TrainStations",
                column: "TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStation_Routes_RouteId",
                table: "RouteStation",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStation_Stations_EndStationId",
                table: "RouteStation",
                column: "EndStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStation_Stations_StartStationId",
                table: "RouteStation",
                column: "StartStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Carriages_CarriageId",
                table: "Seat",
                column: "CarriageId",
                principalTable: "Carriages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_DictionaryItems_SeatTypeId",
                table: "Seat",
                column: "SeatTypeId",
                principalTable: "DictionaryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDiscount_Discounts_DiscountId",
                table: "TicketDiscount",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDiscount_Tickets_TicketId",
                table: "TicketDiscount",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Train_DictionaryItems_TypeId",
                table: "Train",
                column: "TypeId",
                principalTable: "DictionaryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainCarriage_Carriages_CarriageId",
                table: "TrainCarriage",
                column: "CarriageId",
                principalTable: "Carriages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainCarriage_Train_TrainId",
                table: "TrainCarriage",
                column: "TrainId",
                principalTable: "Train",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainStations_Train_TrainId",
                table: "TrainStations",
                column: "TrainId",
                principalTable: "Train",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
