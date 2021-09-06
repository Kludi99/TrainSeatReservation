using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class AddDictionaryItemsToCarriage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carriage_CarriageClassId",
                table: "Carriage");

            migrationBuilder.DropIndex(
                name: "IX_Carriage_TypeId",
                table: "Carriage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "965df2eb-7f7c-4597-94ef-007a9bce2184");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9cdb8cf-b087-41a7-b5f8-9e9cc19fae11");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e64d50ec-e872-4e16-bbbe-a3dd6c556241", "d2f85834-bf52-44d9-845b-16b10dcf4176", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c815eb34-869e-4fe2-8a59-6e29f3c3e1f2", "98d4fcc7-71d3-42f5-b932-1a1dc6745dc5", "Client", "CLIENT" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carriage_CarriageClassId",
                table: "Carriage");

            migrationBuilder.DropIndex(
                name: "IX_Carriage_Id",
                table: "Carriage");

            migrationBuilder.DropIndex(
                name: "IX_Carriage_TypeId",
                table: "Carriage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c815eb34-869e-4fe2-8a59-6e29f3c3e1f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e64d50ec-e872-4e16-bbbe-a3dd6c556241");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "965df2eb-7f7c-4597-94ef-007a9bce2184", "a9ff61ba-2d3b-4504-8a69-eb6c6b8d574d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9cdb8cf-b087-41a7-b5f8-9e9cc19fae11", "dc09e788-deb5-4806-83c6-9e428c70ed22", "Client", "CLIENT" });

            migrationBuilder.CreateIndex(
                name: "IX_Carriage_CarriageClassId",
                table: "Carriage",
                column: "CarriageClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Carriage_TypeId",
                table: "Carriage",
                column: "TypeId");
        }
    }
}
