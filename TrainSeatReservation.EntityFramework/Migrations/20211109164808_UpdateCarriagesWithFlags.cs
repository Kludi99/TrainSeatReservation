using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class UpdateCarriagesWithFlags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15e0241d-914f-4099-9633-bd383274588e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa6f7c6b-a5d7-4a8a-bc0d-00d4ab8d1603");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "87400d76-f016-4111-84b3-97468281f1f7", "eecab211-fe05-49ea-b51b-48489966ed04", "Admin", "ADMIN" },
                    { "f7e6c141-1279-4c4f-a106-97b2eab71941", "72fe0c7a-af2d-4cd5-8831-4d68d351dbbd", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BicyclePlace", "EletricalOutlet" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 4,
                column: "BicyclePlace",
                value: true);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 7,
                column: "BicyclePlace",
                value: true);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 11,
                column: "EletricalOutlet",
                value: true);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 12,
                column: "EletricalOutlet",
                value: true);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 13,
                column: "EletricalOutlet",
                value: true);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 14,
                column: "EletricalOutlet",
                value: true);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 15,
                column: "EletricalOutlet",
                value: true);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 16,
                column: "EletricalOutlet",
                value: true);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 17,
                column: "EletricalOutlet",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87400d76-f016-4111-84b3-97468281f1f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7e6c141-1279-4c4f-a106-97b2eab71941");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aa6f7c6b-a5d7-4a8a-bc0d-00d4ab8d1603", "1d0ab432-7e03-4e8d-b002-1a443e8179d4", "Admin", "ADMIN" },
                    { "15e0241d-914f-4099-9633-bd383274588e", "f36fab1a-71d5-4b9c-b752-26b64871a563", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BicyclePlace", "EletricalOutlet" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 4,
                column: "BicyclePlace",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 7,
                column: "BicyclePlace",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 11,
                column: "EletricalOutlet",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 12,
                column: "EletricalOutlet",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 13,
                column: "EletricalOutlet",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 14,
                column: "EletricalOutlet",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 15,
                column: "EletricalOutlet",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 16,
                column: "EletricalOutlet",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carriages",
                keyColumn: "Id",
                keyValue: 17,
                column: "EletricalOutlet",
                value: null);
        }
    }
}
