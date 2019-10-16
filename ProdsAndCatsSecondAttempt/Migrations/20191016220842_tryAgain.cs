using Microsoft.EntityFrameworkCore.Migrations;

namespace ProdsAndCatsSecondAttempt.Migrations
{
    public partial class tryAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "someDumbChange",
                table: "Categorie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "someDumbChange",
                table: "Categorie");
        }
    }
}
