using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeathernyCocktails.Migrations
{
    public partial class Collection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionID",
                table: "Cocktail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Collect = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cocktail_CollectionID",
                table: "Cocktail",
                column: "CollectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cocktail_Collection_CollectionID",
                table: "Cocktail",
                column: "CollectionID",
                principalTable: "Collection",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cocktail_Collection_CollectionID",
                table: "Cocktail");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropIndex(
                name: "IX_Cocktail_CollectionID",
                table: "Cocktail");

            migrationBuilder.DropColumn(
                name: "CollectionID",
                table: "Cocktail");
        }
    }
}
