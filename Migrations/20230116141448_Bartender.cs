using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeathernyCocktails.Migrations
{
    public partial class Bartender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bartender",
                table: "Cocktail");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Cocktail",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "BartenderID",
                table: "Cocktail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bartender",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bartender", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cocktail_BartenderID",
                table: "Cocktail",
                column: "BartenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cocktail_Bartender_BartenderID",
                table: "Cocktail",
                column: "BartenderID",
                principalTable: "Bartender",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cocktail_Bartender_BartenderID",
                table: "Cocktail");

            migrationBuilder.DropTable(
                name: "Bartender");

            migrationBuilder.DropIndex(
                name: "IX_Cocktail_BartenderID",
                table: "Cocktail");

            migrationBuilder.DropColumn(
                name: "BartenderID",
                table: "Cocktail");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Cocktail",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AddColumn<string>(
                name: "Bartender",
                table: "Cocktail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
