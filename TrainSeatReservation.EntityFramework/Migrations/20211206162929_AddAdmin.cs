using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class AddAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "214406c5-d7d8-48d5-9a2a-d47db67daab7");

            migrationBuilder.CreateTable(
                name: "IdentityUserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole", x => new { x.RoleId, x.UserId });
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16cff0e8-a7c6-4a7f-ae34-5e18425508ee",
                column: "ConcurrencyStamp",
                value: "cbd9d29c-0d08-45ec-baef-181c49366238");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9476520c-e1f3-4bf7-85a1-6aeb66384c17", "c4e1748e-9926-4988-a9fe-aa24498e8646", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1111111-1111-1111-1111-11111111", 0, "aa34be41-2446-4dcf-8f14-49e3e6213dc1", "train.reservation.mvc@gmail.com", false, false, null, "Admin", "TRAIN.RESERVATION.MVC@GMAIL.COM", "TRAIN.RESERVATION.MVC@GMAIL.COM", "AQAAAAEAACcQAAAAEG2EiQ4xwwRjyB5BUbEYJMmdkIsiBN7bihRafRTHdi0CSyvupbOivOv2po6w9bST0A==", null, false, "24fbe799-d4d1-4b8b-9415-02b7d9353e4e", "Admin", false, "train.reservation.mvc@gmail.com" });

            migrationBuilder.InsertData(
                table: "IdentityUserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "16cff0e8-a7c6-4a7f-ae34-5e18425508ee", "1111111-1111-1111-1111-11111111" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserRole");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9476520c-e1f3-4bf7-85a1-6aeb66384c17");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1111111-1111-1111-1111-11111111");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16cff0e8-a7c6-4a7f-ae34-5e18425508ee",
                column: "ConcurrencyStamp",
                value: "419978b0-94c0-48da-a365-64c0063c8168");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "214406c5-d7d8-48d5-9a2a-d47db67daab7", "2a06e9f8-741f-4616-ab58-573be40bcba5", "Client", "CLIENT" });
        }
    }
}
