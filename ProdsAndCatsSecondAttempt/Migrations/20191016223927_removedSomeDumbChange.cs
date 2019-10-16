using Microsoft.EntityFrameworkCore.Migrations;

namespace ProdsAndCatsSecondAttempt.Migrations
{
    public partial class removedSomeDumbChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "someDumbChange",
                table: "Categorie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "someDumbChange",
                table: "Categorie",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
