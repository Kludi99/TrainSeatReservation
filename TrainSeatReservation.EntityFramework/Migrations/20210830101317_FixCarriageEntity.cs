//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class FixCarriageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carriage_Dictionaries_CarriageClassId",
                table: "Carriage");

            migrationBuilder.DropForeignKey(
                name: "FK_Carriage_Dictionaries_TypeId",
                table: "Carriage");

            migrationBuilder.AddForeignKey(
                name: "FK_Carriage_DictionaryItems_CarriageClassId",
                table: "Carriage",
                column: "CarriageClassId",
                principalTable: "DictionaryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carriage_DictionaryItems_TypeId",
                table: "Carriage",
                column: "TypeId",
                principalTable: "DictionaryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carriage_DictionaryItems_CarriageClassId",
                table: "Carriage");

            migrationBuilder.DropForeignKey(
                name: "FK_Carriage_DictionaryItems_TypeId",
                table: "Carriage");

            migrationBuilder.AddForeignKey(
                name: "FK_Carriage_Dictionaries_CarriageClassId",
                table: "Carriage",
                column: "CarriageClassId",
                principalTable: "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carriage_Dictionaries_TypeId",
                table: "Carriage",
                column: "TypeId",
                principalTable: "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
