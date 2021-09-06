using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class UpdateDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carriage_DictionaryItem_CarriageClassId",
                table: "Carriage");

            migrationBuilder.DropForeignKey(
                name: "FK_Carriage_DictionaryItem_TypeId",
                table: "Carriage");

            migrationBuilder.DropForeignKey(
                name: "FK_DictionaryItem_Dictionary_DictionaryId",
                table: "DictionaryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteStation_Route_RouteId",
                table: "RouteStation");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteStation_Station_EndStationId",
                table: "RouteStation");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteStation_Station_StartStationId",
                table: "RouteStation");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Carriage_CarriageId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_DictionaryItem_SeatTypeId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TrainStation_ArrivalTrainStationId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TrainStation_DepartureTrainStationId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDiscount_Discount_DiscountId",
                table: "TicketDiscount");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDiscount_Ticket_TicketId",
                table: "TicketDiscount");

            migrationBuilder.DropForeignKey(
                name: "FK_Train_DictionaryItem_TypeId",
                table: "Train");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainCarriage_Carriage_CarriageId",
                table: "TrainCarriage");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStation_Station_StationId",
                table: "TrainStation");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStation_Train_TrainId",
                table: "TrainStation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainStation",
                table: "TrainStation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Station",
                table: "Station");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Route",
                table: "Route");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discount",
                table: "Discount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DictionaryItem",
                table: "DictionaryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dictionary",
                table: "Dictionary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carriage",
                table: "Carriage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0748269e-768b-4b1d-8086-64fe62829b3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "756ecae4-8002-47a7-94c5-14e36088e595");

            migrationBuilder.RenameTable(
                name: "TrainStation",
                newName: "TrainStations");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "Station",
                newName: "Stations");

            migrationBuilder.RenameTable(
                name: "Route",
                newName: "Routes");

            migrationBuilder.RenameTable(
                name: "Discount",
                newName: "Discounts");

            migrationBuilder.RenameTable(
                name: "DictionaryItem",
                newName: "DictionaryItems");

            migrationBuilder.RenameTable(
                name: "Dictionary",
                newName: "Dictionaries");

            migrationBuilder.RenameTable(
                name: "Carriage",
                newName: "Carriages");

            migrationBuilder.RenameIndex(
                name: "IX_TrainStation_TrainId",
                table: "TrainStations",
                newName: "IX_TrainStations_TrainId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainStation_StationId",
                table: "TrainStations",
                newName: "IX_TrainStations_StationId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_UserId",
                table: "Tickets",
                newName: "IX_Tickets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_DepartureTrainStationId",
                table: "Tickets",
                newName: "IX_Tickets_DepartureTrainStationId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_ArrivalTrainStationId",
                table: "Tickets",
                newName: "IX_Tickets_ArrivalTrainStationId");

            migrationBuilder.RenameIndex(
                name: "IX_DictionaryItem_DictionaryId",
                table: "DictionaryItems",
                newName: "IX_DictionaryItems_DictionaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Carriage_TypeId",
                table: "Carriages",
                newName: "IX_Carriages_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Carriage_CarriageClassId",
                table: "Carriages",
                newName: "IX_Carriages_CarriageClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainStations",
                table: "TrainStations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stations",
                table: "Stations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routes",
                table: "Routes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DictionaryItems",
                table: "DictionaryItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dictionaries",
                table: "Dictionaries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carriages",
                table: "Carriages",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "078f51a5-97fa-498c-965a-79ec3a6fade1", "39aa0251-0995-4c66-b198-f86368c422bb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc95084f-de39-4a1a-a6f8-926a5d53bf8e", "a8c21a36-87e6-4f03-bb47-adcb8678e299", "Client", "CLIENT" });

            migrationBuilder.AddForeignKey(
                name: "FK_Carriages_DictionaryItems_CarriageClassId",
                table: "Carriages",
                column: "CarriageClassId",
                principalTable: "DictionaryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carriages_DictionaryItems_TypeId",
                table: "Carriages",
                column: "TypeId",
                principalTable: "DictionaryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DictionaryItems_Dictionaries_DictionaryId",
                table: "DictionaryItems",
                column: "DictionaryId",
                principalTable: "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStation_Stations_StartStationId",
                table: "RouteStation",
                column: "StartStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Tickets_AspNetUsers_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TrainStations_ArrivalTrainStationId",
                table: "Tickets",
                column: "ArrivalTrainStationId",
                principalTable: "TrainStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TrainStations_DepartureTrainStationId",
                table: "Tickets",
                column: "DepartureTrainStationId",
                principalTable: "TrainStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_TrainStations_Stations_StationId",
                table: "TrainStations",
                column: "StationId",
                principalTable: "Stations",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carriages_DictionaryItems_CarriageClassId",
                table: "Carriages");

            migrationBuilder.DropForeignKey(
                name: "FK_Carriages_DictionaryItems_TypeId",
                table: "Carriages");

            migrationBuilder.DropForeignKey(
                name: "FK_DictionaryItems_Dictionaries_DictionaryId",
                table: "DictionaryItems");

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
                name: "FK_Tickets_AspNetUsers_UserId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TrainStations_ArrivalTrainStationId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TrainStations_DepartureTrainStationId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Train_DictionaryItems_TypeId",
                table: "Train");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainCarriage_Carriages_CarriageId",
                table: "TrainCarriage");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStations_Stations_StationId",
                table: "TrainStations");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStations_Train_TrainId",
                table: "TrainStations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainStations",
                table: "TrainStations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stations",
                table: "Stations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routes",
                table: "Routes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DictionaryItems",
                table: "DictionaryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dictionaries",
                table: "Dictionaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carriages",
                table: "Carriages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "078f51a5-97fa-498c-965a-79ec3a6fade1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc95084f-de39-4a1a-a6f8-926a5d53bf8e");

            migrationBuilder.RenameTable(
                name: "TrainStations",
                newName: "TrainStation");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "Stations",
                newName: "Station");

            migrationBuilder.RenameTable(
                name: "Routes",
                newName: "Route");

            migrationBuilder.RenameTable(
                name: "Discounts",
                newName: "Discount");

            migrationBuilder.RenameTable(
                name: "DictionaryItems",
                newName: "DictionaryItem");

            migrationBuilder.RenameTable(
                name: "Dictionaries",
                newName: "Dictionary");

            migrationBuilder.RenameTable(
                name: "Carriages",
                newName: "Carriage");

            migrationBuilder.RenameIndex(
                name: "IX_TrainStations_TrainId",
                table: "TrainStation",
                newName: "IX_TrainStation_TrainId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainStations_StationId",
                table: "TrainStation",
                newName: "IX_TrainStation_StationId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UserId",
                table: "Ticket",
                newName: "IX_Ticket_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_DepartureTrainStationId",
                table: "Ticket",
                newName: "IX_Ticket_DepartureTrainStationId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ArrivalTrainStationId",
                table: "Ticket",
                newName: "IX_Ticket_ArrivalTrainStationId");

            migrationBuilder.RenameIndex(
                name: "IX_DictionaryItems_DictionaryId",
                table: "DictionaryItem",
                newName: "IX_DictionaryItem_DictionaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Carriages_TypeId",
                table: "Carriage",
                newName: "IX_Carriage_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Carriages_CarriageClassId",
                table: "Carriage",
                newName: "IX_Carriage_CarriageClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainStation",
                table: "TrainStation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Station",
                table: "Station",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Route",
                table: "Route",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discount",
                table: "Discount",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DictionaryItem",
                table: "DictionaryItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dictionary",
                table: "Dictionary",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carriage",
                table: "Carriage",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0748269e-768b-4b1d-8086-64fe62829b3c", "ee2360ec-5ec4-4f01-bece-2a31cc718de1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "756ecae4-8002-47a7-94c5-14e36088e595", "362ddcde-54c7-4687-b288-23577b26640c", "Client", "CLIENT" });

            migrationBuilder.AddForeignKey(
                name: "FK_Carriage_DictionaryItem_CarriageClassId",
                table: "Carriage",
                column: "CarriageClassId",
                principalTable: "DictionaryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carriage_DictionaryItem_TypeId",
                table: "Carriage",
                column: "TypeId",
                principalTable: "DictionaryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DictionaryItem_Dictionary_DictionaryId",
                table: "DictionaryItem",
                column: "DictionaryId",
                principalTable: "Dictionary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStation_Route_RouteId",
                table: "RouteStation",
                column: "RouteId",
                principalTable: "Route",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStation_Station_EndStationId",
                table: "RouteStation",
                column: "EndStationId",
                principalTable: "Station",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteStation_Station_StartStationId",
                table: "RouteStation",
                column: "StartStationId",
                principalTable: "Station",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Carriage_CarriageId",
                table: "Seat",
                column: "CarriageId",
                principalTable: "Carriage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_DictionaryItem_SeatTypeId",
                table: "Seat",
                column: "SeatTypeId",
                principalTable: "DictionaryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId",
                table: "Ticket",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TrainStation_ArrivalTrainStationId",
                table: "Ticket",
                column: "ArrivalTrainStationId",
                principalTable: "TrainStation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TrainStation_DepartureTrainStationId",
                table: "Ticket",
                column: "DepartureTrainStationId",
                principalTable: "TrainStation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDiscount_Discount_DiscountId",
                table: "TicketDiscount",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDiscount_Ticket_TicketId",
                table: "TicketDiscount",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Train_DictionaryItem_TypeId",
                table: "Train",
                column: "TypeId",
                principalTable: "DictionaryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainCarriage_Carriage_CarriageId",
                table: "TrainCarriage",
                column: "CarriageId",
                principalTable: "Carriage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainStation_Station_StationId",
                table: "TrainStation",
                column: "StationId",
                principalTable: "Station",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainStation_Train_TrainId",
                table: "TrainStation",
                column: "TrainId",
                principalTable: "Train",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
