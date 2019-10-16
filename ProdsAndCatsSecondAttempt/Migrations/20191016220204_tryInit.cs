using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProdsAndCatsSecondAttempt.Migrations
{
    public partial class tryInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    CategorieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.CategorieID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "ProductJoinCategorys",
                columns: table => new
                {
                    ProductJoinCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    CategorieID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductJoinCategorys", x => x.ProductJoinCategoryID);
                    table.ForeignKey(
                        name: "FK_ProductJoinCategorys_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "CategorieID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductJoinCategorys_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductJoinCategorys_CategorieID",
                table: "ProductJoinCategorys",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductJoinCategorys_ProductID",
                table: "ProductJoinCategorys",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductJoinCategorys");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
