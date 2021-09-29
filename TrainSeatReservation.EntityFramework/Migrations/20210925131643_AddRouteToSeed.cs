using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class AddRouteToSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05f48e72-0ee0-429c-a2dc-b046d050bf57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25709c2c-e2da-4051-bf85-a4b4bd84905a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c1908a05-673c-41c1-a210-5e5a2e5ab4f8", "ed8494d0-79e9-4ead-835d-fb8e79700a7b", "Admin", "ADMIN" },
                    { "d26f87a6-3580-434e-ac4e-0ffbc7babc70", "5b119b17-f9e4-4a51-9abd-3cc6e8f65679", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Name", "TrainId" },
                values: new object[] { 3, "Gdynia Główna - Bohumin", 3 });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "City", "Name" },
                values: new object[,]
                {
                    { 55, "Chałupki", "Chałupki" },
                    { 54, "Wodzisław Śląski", "Wodzisław Śląski" },
                    { 53, "Rybnik", "Rybnik" },
                    { 52, "Tychy", "Tychy" },
                    { 51, "Katowice", "Katowice" },
                    { 50, "Sosnowiec", "Sosnowiec Główny" },
                    { 49, "Zawiercie", "Zawiercie" },
                    { 48, "Działdowo", "Działdowo" },
                    { 56, "Bohumin", "Bohumin" },
                    { 46, "Malbork", "Malbork" },
                    { 45, "Tczew", "Tczew" },
                    { 44, "Gdańsk", "Gdańsk Główny" },
                    { 43, "Gdańsk", "Gdańsk Wrzeszcz" },
                    { 42, "Gdańsk", "Gdańsk Oliwa" },
                    { 41, "Sopot", "Sopot" },
                    { 40, "Gdynia", "Gdynia Główna" },
                    { 47, "Iława", "Iława Główna" }
                });

            migrationBuilder.InsertData(
                table: "TrainTimeTables",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "StartingDateOfTimeTable" },
                values: new object[,]
                {
                    { 62, new TimeSpan(0, 14, 21, 0, 0), new TimeSpan(0, 14, 22, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, new TimeSpan(0, 16, 15, 0, 0), new TimeSpan(0, 16, 16, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, new TimeSpan(0, 16, 42, 0, 0), new TimeSpan(0, 16, 43, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, new TimeSpan(0, 17, 53, 0, 0), new TimeSpan(0, 17, 54, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, new TimeSpan(0, 17, 21, 0, 0), new TimeSpan(0, 17, 24, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, new TimeSpan(0, 14, 10, 0, 0), new TimeSpan(0, 14, 17, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, new TimeSpan(0, 18, 8, 0, 0), new TimeSpan(0, 18, 9, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, new TimeSpan(0, 16, 52, 0, 0), new TimeSpan(0, 17, 5, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, new TimeSpan(0, 14, 1, 0, 0), new TimeSpan(0, 14, 4, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, new TimeSpan(0, 11, 32, 0, 0), new TimeSpan(0, 11, 33, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, new TimeSpan(0, 12, 20, 0, 0), new TimeSpan(0, 12, 21, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, new TimeSpan(0, 11, 44, 0, 0), new TimeSpan(0, 11, 45, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, new TimeSpan(0, 11, 13, 0, 0), new TimeSpan(0, 11, 16, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, new TimeSpan(0, 11, 7, 0, 0), new TimeSpan(0, 11, 8, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, new TimeSpan(0, 11, 3, 0, 0), new TimeSpan(0, 11, 4, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, new TimeSpan(0, 10, 58, 0, 0), new TimeSpan(0, 10, 59, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, null, new TimeSpan(0, 10, 51, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, new TimeSpan(0, 18, 26, 0, 0), new TimeSpan(0, 18, 27, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, new TimeSpan(0, 12, 52, 0, 0), new TimeSpan(0, 12, 53, 0, 0), new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, new TimeSpan(0, 18, 33, 0, 0), null, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RouteStations",
                columns: new[] { "Id", "Distance", "EndStationId", "Order", "Price", "RouteId", "StartStationId" },
                values: new object[,]
                {
                    { 58, 23, 15, 10, 5.0, 3, 14 },
                    { 67, 32, 56, 19, 5.0, 3, 55 },
                    { 66, 45, 55, 18, 5.0, 3, 54 },
                    { 65, 17, 54, 17, 5.0, 3, 53 },
                    { 64, 20, 53, 16, 5.0, 3, 52 },
                    { 63, 36, 52, 15, 5.0, 3, 51 },
                    { 61, 30, 50, 13, 5.0, 3, 49 },
                    { 60, 23, 49, 12, 5.0, 3, 16 },
                    { 57, 32, 14, 9, 5.0, 3, 48 },
                    { 62, 20, 51, 14, 5.0, 3, 50 },
                    { 55, 17, 47, 7, 5.0, 3, 46 },
                    { 56, 45, 37, 8, 5.0, 3, 47 },
                    { 49, 23, 41, 1, 5.0, 3, 40 },
                    { 50, 21, 42, 2, 5.0, 3, 41 },
                    { 51, 30, 43, 3, 5.0, 3, 42 },
                    { 59, 23, 16, 11, 5.0, 3, 15 },
                    { 53, 36, 45, 5, 5.0, 3, 44 },
                    { 54, 20, 46, 6, 5.0, 3, 45 },
                    { 52, 20, 44, 4, 5.0, 3, 43 }
                });

            migrationBuilder.InsertData(
                table: "TrainStations",
                columns: new[] { "Id", "StationId", "TrainId", "TrainTimeTableId" },
                values: new object[,]
                {
                    { 61, 15, 3, 61 },
                    { 68, 54, 3, 68 },
                    { 67, 53, 3, 67 },
                    { 66, 52, 3, 66 },
                    { 65, 51, 3, 65 },
                    { 64, 50, 3, 64 },
                    { 63, 49, 3, 63 },
                    { 62, 16, 3, 62 },
                    { 60, 14, 3, 60 },
                    { 51, 40, 3, 51 },
                    { 58, 47, 3, 58 },
                    { 57, 46, 3, 57 },
                    { 56, 45, 3, 56 },
                    { 55, 44, 3, 55 },
                    { 54, 43, 3, 54 },
                    { 53, 42, 3, 53 },
                    { 52, 41, 3, 52 },
                    { 69, 55, 3, 69 },
                    { 59, 48, 3, 59 },
                    { 70, 56, 3, 70 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1908a05-673c-41c1-a210-5e5a2e5ab4f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d26f87a6-3580-434e-ac4e-0ffbc7babc70");

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "RouteStations",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "TrainStations",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "TrainTimeTables",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25709c2c-e2da-4051-bf85-a4b4bd84905a", "84b03216-597c-46ad-9cc5-1327e530cc70", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05f48e72-0ee0-429c-a2dc-b046d050bf57", "18033f36-115e-49e4-b6db-c759e11ffeff", "Client", "CLIENT" });
        }
    }
}
