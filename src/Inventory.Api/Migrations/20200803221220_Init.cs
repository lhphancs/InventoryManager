using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inventory.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shelf",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShelfLocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Row = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelfLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelfLocation_Shelf_Id",
                        column: x => x.Id,
                        principalTable: "Shelf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Upc = table.Column<string>(nullable: true),
                    ProductInfo_Brand = table.Column<string>(nullable: true),
                    ProductInfo_Name = table.Column<string>(nullable: true),
                    ProductInfo_Description = table.Column<string>(nullable: true),
                    ProductInfo_ExpirationLocation = table.Column<string>(nullable: true),
                    ProductInfo_OunceWeight = table.Column<int>(nullable: true),
                    ProductPreparationInfo_RequiresBubbleWrap = table.Column<bool>(nullable: true),
                    ProductPreparationInfo_RequiresPadding = table.Column<bool>(nullable: true),
                    ProductPreparationInfo_RequiresBox = table.Column<bool>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ShelfLocationId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ShelfLocation_ShelfLocationId",
                        column: x => x.ShelfLocationId,
                        principalTable: "ShelfLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShelfLocationId",
                table: "Products",
                column: "ShelfLocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Upc",
                table: "Products",
                column: "Upc",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShelfLocation");

            migrationBuilder.DropTable(
                name: "Shelf");
        }
    }
}
