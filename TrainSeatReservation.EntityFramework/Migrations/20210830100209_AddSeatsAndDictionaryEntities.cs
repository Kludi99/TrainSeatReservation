using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class AddSeatsAndDictionaryEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Carriage");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Train",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CarriageClassId",
                table: "Carriage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Carriage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Carriage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DictionaryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictionaryItems_Dictionaries_DictionaryId",
                        column: x => x.DictionaryId,
                        principalTable: "Dictionaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    SeatTypeId = table.Column<int>(type: "int", nullable: false),
                    CarriageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Carriage_CarriageId",
                        column: x => x.CarriageId,
                        principalTable: "Carriage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seats_DictionaryItems_SeatTypeId",
                        column: x => x.SeatTypeId,
                        principalTable: "DictionaryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carriage_CarriageClassId",
                table: "Carriage",
                column: "CarriageClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Carriage_TypeId",
                table: "Carriage",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryItems_DictionaryId",
                table: "DictionaryItems",
                column: "DictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_CarriageId",
                table: "Seats",
                column: "CarriageId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeatTypeId",
                table: "Seats",
                column: "SeatTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carriage_Dictionaries_CarriageClassId",
                table: "Carriage",
                column: "CarriageClassId",
                principalTable: "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carriage_Dictionaries_TypeId",
                table: "Carriage",
                column: "TypeId",
                principalTable: "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carriage_Dictionaries_CarriageClassId",
                table: "Carriage");

            migrationBuilder.DropForeignKey(
                name: "FK_Carriage_Dictionaries_TypeId",
                table: "Carriage");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "DictionaryItems");

            migrationBuilder.DropTable(
                name: "Dictionaries");

            migrationBuilder.DropIndex(
                name: "IX_Carriage_CarriageClassId",
                table: "Carriage");

            migrationBuilder.DropIndex(
                name: "IX_Carriage_TypeId",
                table: "Carriage");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Train");

            migrationBuilder.DropColumn(
                name: "CarriageClassId",
                table: "Carriage");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Carriage");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Carriage");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Carriage",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
