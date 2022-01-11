//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class UpdateTicketWithCarriagesIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28cd66e7-f6bc-481d-8323-09ecfdf56a78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d04d0e70-7d77-4dd8-875b-e03020224da7");

            migrationBuilder.AddColumn<int>(
                name: "SecondCarriageId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThirdCarriageId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cdad6042-6008-4309-973d-9682a0135720", "516245bc-0441-4897-81aa-b2189a6fb3be", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cf69d14-bdbb-4fc3-8a46-676d6324fa6c", "42f52426-d27c-42e5-a8c4-d18d26f1a1f5", "Client", "CLIENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cf69d14-bdbb-4fc3-8a46-676d6324fa6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdad6042-6008-4309-973d-9682a0135720");

            migrationBuilder.DropColumn(
                name: "SecondCarriageId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ThirdCarriageId",
                table: "Tickets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28cd66e7-f6bc-481d-8323-09ecfdf56a78", "26aeddcf-4e33-4401-95eb-a9fbeff06832", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d04d0e70-7d77-4dd8-875b-e03020224da7", "724933d2-41ed-4c8d-b00c-0b99ac88b18b", "Client", "CLIENT" });
        }
    }
}
