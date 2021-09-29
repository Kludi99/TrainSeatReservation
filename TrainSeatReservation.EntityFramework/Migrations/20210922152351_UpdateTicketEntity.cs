using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class UpdateTicketEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89e8b357-a3ac-46e1-aad1-4cbc1062afbc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db4eab58-98d5-488f-847e-735472c66737");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25709c2c-e2da-4051-bf85-a4b4bd84905a", "84b03216-597c-46ad-9cc5-1327e530cc70", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05f48e72-0ee0-429c-a2dc-b046d050bf57", "18033f36-115e-49e4-b6db-c759e11ffeff", "Client", "CLIENT" });

            migrationBuilder.CreateIndex(
                name: "IX_Seats_TicketId",
                table: "Seats",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Tickets_TicketId",
                table: "Seats",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Tickets_TicketId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_TicketId",
                table: "Seats");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05f48e72-0ee0-429c-a2dc-b046d050bf57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25709c2c-e2da-4051-bf85-a4b4bd84905a");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Seats");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89e8b357-a3ac-46e1-aad1-4cbc1062afbc", "c20d4e8d-a1b0-4375-b0b4-1155d996b2b1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db4eab58-98d5-488f-847e-735472c66737", "62b7bca8-7c3d-4761-9583-24c1ce97e6ed", "Client", "CLIENT" });
        }
    }
}
