//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class UpdateDictionaryItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Carriage_CarriageId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_DictionaryItem_SeatTypeId",
                table: "Seats");

           /* migrationBuilder.DropIndex(
                name: "IX_Carriage_CarriageClassId",
                table: "Carriage"); 

            migrationBuilder.DropIndex(
                name: "IX_Carriage_Id",
                table: "Carriage");

            migrationBuilder.DropIndex(
                name: "IX_Carriage_TypeId",
                table: "Carriage");*/

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c815eb34-869e-4fe2-8a59-6e29f3c3e1f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e64d50ec-e872-4e16-bbbe-a3dd6c556241");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_SeatTypeId",
                table: "Seat",
                newName: "IX_Seat_SeatTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_CarriageId",
                table: "Seat",
                newName: "IX_Seat_CarriageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0748269e-768b-4b1d-8086-64fe62829b3c", "ee2360ec-5ec4-4f01-bece-2a31cc718de1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "756ecae4-8002-47a7-94c5-14e36088e595", "362ddcde-54c7-4687-b288-23577b26640c", "Client", "CLIENT" });

            migrationBuilder.CreateIndex(
                name: "IX_Carriage_CarriageClassId",
                table: "Carriage",
                column: "CarriageClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Carriage_TypeId",
                table: "Carriage",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Carriage_CarriageId",
                table: "Seat",
                column: "CarriageId",
                principalTable: "Carriage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_DictionaryItem_SeatTypeId",
                table: "Seat",
                column: "SeatTypeId",
                principalTable: "DictionaryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Carriage_CarriageId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_DictionaryItem_SeatTypeId",
                table: "Seat");

          /*  migrationBuilder.DropIndex(
                name: "IX_Carriage_CarriageClassId",
                table: "Carriage");
          */
            migrationBuilder.DropIndex(
                name: "IX_Carriage_TypeId",
                table: "Carriage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0748269e-768b-4b1d-8086-64fe62829b3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "756ecae4-8002-47a7-94c5-14e36088e595");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_SeatTypeId",
                table: "Seats",
                newName: "IX_Seats_SeatTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_CarriageId",
                table: "Seats",
                newName: "IX_Seats_CarriageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e64d50ec-e872-4e16-bbbe-a3dd6c556241", "d2f85834-bf52-44d9-845b-16b10dcf4176", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c815eb34-869e-4fe2-8a59-6e29f3c3e1f2", "98d4fcc7-71d3-42f5-b932-1a1dc6745dc5", "Client", "CLIENT" });

            migrationBuilder.CreateIndex(
                name: "IX_Carriage_CarriageClassId",
                table: "Carriage",
                column: "CarriageClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carriage_Id",
                table: "Carriage",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carriage_TypeId",
                table: "Carriage",
                column: "TypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Carriage_CarriageId",
                table: "Seats",
                column: "CarriageId",
                principalTable: "Carriage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_DictionaryItem_SeatTypeId",
                table: "Seats",
                column: "SeatTypeId",
                principalTable: "DictionaryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
