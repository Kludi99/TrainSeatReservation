using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class AddAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserRole");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9476520c-e1f3-4bf7-85a1-6aeb66384c17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16cff0e8-a7c6-4a7f-ae34-5e18425508ee",
                column: "ConcurrencyStamp",
                value: "a437c795-0e4b-4f06-8a87-19614eaa75d5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e227ea38-2549-49bb-ad08-29a01d16706e", "9b452183-3294-47a1-b135-8dd2e04c86ba", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "16cff0e8-a7c6-4a7f-ae34-5e18425508ee", "1111111-1111-1111-1111-11111111" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1111111-1111-1111-1111-11111111",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d353da2a-26c4-4ff4-9434-68b66e69fe80", true, "AQAAAAEAACcQAAAAEE7aR4/qdU5ljfiMEqajy37Qn2N/JuYF2xTA5OuZZfeFQCLN+SEvQfsPklwRigE3qw==", "75c15da5-5765-4bf8-8d5a-c1617bcdd567" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e227ea38-2549-49bb-ad08-29a01d16706e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "16cff0e8-a7c6-4a7f-ae34-5e18425508ee", "1111111-1111-1111-1111-11111111" });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1111111-1111-1111-1111-11111111",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa34be41-2446-4dcf-8f14-49e3e6213dc1", false, "AQAAAAEAACcQAAAAEG2EiQ4xwwRjyB5BUbEYJMmdkIsiBN7bihRafRTHdi0CSyvupbOivOv2po6w9bST0A==", "24fbe799-d4d1-4b8b-9415-02b7d9353e4e" });

            migrationBuilder.InsertData(
                table: "IdentityUserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "16cff0e8-a7c6-4a7f-ae34-5e18425508ee", "1111111-1111-1111-1111-11111111" });
        }
    }
}
