//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class AddRouteToTrainEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "023e8964-0220-4bc2-9e1e-ab6e6c5f1c81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d365021b-8ff2-49ab-83e6-976debfca6a8");

            migrationBuilder.AddColumn<int>(
                name: "TrainId",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "89e8b357-a3ac-46e1-aad1-4cbc1062afbc", "c20d4e8d-a1b0-4375-b0b4-1155d996b2b1", "Admin", "ADMIN" },
                    { "db4eab58-98d5-488f-847e-735472c66737", "62b7bca8-7c3d-4761-9583-24c1ce97e6ed", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "TrainId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "TrainId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_TrainId",
                table: "Routes",
                column: "TrainId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Trains_TrainId",
                table: "Routes",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Trains_TrainId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_TrainId",
                table: "Routes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89e8b357-a3ac-46e1-aad1-4cbc1062afbc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db4eab58-98d5-488f-847e-735472c66737");

            migrationBuilder.DropColumn(
                name: "TrainId",
                table: "Routes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d365021b-8ff2-49ab-83e6-976debfca6a8", "45cc1693-0ea6-473a-8a4e-2f6c2b91f53f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "023e8964-0220-4bc2-9e1e-ab6e6c5f1c81", "0ba7d32b-c727-4c91-889e-3704669fdf47", "Client", "CLIENT" });
        }
    }
}
