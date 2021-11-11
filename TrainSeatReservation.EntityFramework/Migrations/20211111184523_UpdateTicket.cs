using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class UpdateTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87400d76-f016-4111-84b3-97468281f1f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7e6c141-1279-4c4f-a106-97b2eab71941");

            migrationBuilder.AddColumn<int>(
                name: "CarriageId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SendInformation",
                table: "Tickets",
                type: "bit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b7fe95f-ac9b-4d49-b0fe-413f2d429c87", "422cbdf3-fec8-449e-9145-8cd15a11a874", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d466a767-7a6a-4e81-8206-91ae8d9f1801", "9c4e21ec-fc95-4ac8-a8b6-028035bf8c7c", "Client", "CLIENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b7fe95f-ac9b-4d49-b0fe-413f2d429c87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d466a767-7a6a-4e81-8206-91ae8d9f1801");

            migrationBuilder.DropColumn(
                name: "CarriageId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SendInformation",
                table: "Tickets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87400d76-f016-4111-84b3-97468281f1f7", "eecab211-fe05-49ea-b51b-48489966ed04", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7e6c141-1279-4c4f-a106-97b2eab71941", "72fe0c7a-af2d-4cd5-8831-4d68d351dbbd", "Client", "CLIENT" });
        }
    }
}
