using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class builderUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carriage_DictionaryItems_CarriageClassId",
                table: "Carriage");

            migrationBuilder.DropForeignKey(
                name: "FK_Carriage_DictionaryItems_TypeId",
                table: "Carriage");

            migrationBuilder.DropForeignKey(
                name: "FK_DictionaryItems_Dictionaries_DictionaryId",
                table: "DictionaryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_DictionaryItems_SeatTypeId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Train_DictionaryItems_TypeId",
                table: "Train");

            migrationBuilder.DropTable(
                name: "IdentityUserRole<int>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DictionaryItems",
                table: "DictionaryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dictionaries",
                table: "Dictionaries");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36314aae-5188-4403-92f7-69f6dc28a3ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea103caf-c8b1-40e3-afa3-502c40dd623e");

            migrationBuilder.RenameTable(
                name: "DictionaryItems",
                newName: "DictionaryItem");

            migrationBuilder.RenameTable(
                name: "Dictionaries",
                newName: "Dictionary");

            migrationBuilder.RenameIndex(
                name: "IX_DictionaryItems_DictionaryId",
                table: "DictionaryItem",
                newName: "IX_DictionaryItem_DictionaryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DictionaryItem",
                table: "DictionaryItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dictionary",
                table: "Dictionary",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "965df2eb-7f7c-4597-94ef-007a9bce2184", "a9ff61ba-2d3b-4504-8a69-eb6c6b8d574d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9cdb8cf-b087-41a7-b5f8-9e9cc19fae11", "dc09e788-deb5-4806-83c6-9e428c70ed22", "Client", "CLIENT" });

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DictionaryItem_Dictionary_DictionaryId",
                table: "DictionaryItem",
                column: "DictionaryId",
                principalTable: "Dictionary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_DictionaryItem_SeatTypeId",
                table: "Seats",
                column: "SeatTypeId",
                principalTable: "DictionaryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Train_DictionaryItem_TypeId",
                table: "Train",
                column: "TypeId",
                principalTable: "DictionaryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_Seats_DictionaryItem_SeatTypeId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Train_DictionaryItem_TypeId",
                table: "Train");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DictionaryItem",
                table: "DictionaryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dictionary",
                table: "Dictionary");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "965df2eb-7f7c-4597-94ef-007a9bce2184");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9cdb8cf-b087-41a7-b5f8-9e9cc19fae11");

            migrationBuilder.RenameTable(
                name: "DictionaryItem",
                newName: "DictionaryItems");

            migrationBuilder.RenameTable(
                name: "Dictionary",
                newName: "Dictionaries");

            migrationBuilder.RenameIndex(
                name: "IX_DictionaryItem_DictionaryId",
                table: "DictionaryItems",
                newName: "IX_DictionaryItems_DictionaryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DictionaryItems",
                table: "DictionaryItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dictionaries",
                table: "Dictionaries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "IdentityUserRole<int>",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<int>", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea103caf-c8b1-40e3-afa3-502c40dd623e", "faa5bb76-03f1-4e65-99d6-40ba48f7a821", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "36314aae-5188-4403-92f7-69f6dc28a3ad", "60027b71-1764-4fda-ab2e-25788796d259", "Client", "CLIENT" });

            migrationBuilder.AddForeignKey(
                name: "FK_Carriage_DictionaryItems_CarriageClassId",
                table: "Carriage",
                column: "CarriageClassId",
                principalTable: "DictionaryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carriage_DictionaryItems_TypeId",
                table: "Carriage",
                column: "TypeId",
                principalTable: "DictionaryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DictionaryItems_Dictionaries_DictionaryId",
                table: "DictionaryItems",
                column: "DictionaryId",
                principalTable: "Dictionaries",
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
                name: "FK_Train_DictionaryItems_TypeId",
                table: "Train",
                column: "TypeId",
                principalTable: "DictionaryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
