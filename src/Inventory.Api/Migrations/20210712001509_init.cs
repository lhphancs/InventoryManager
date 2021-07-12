using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inventory.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductInfo_Upc = table.Column<string>(nullable: true),
                    ProductInfo_Brand = table.Column<string>(nullable: true),
                    ProductInfo_Name = table.Column<string>(nullable: true),
                    ProductInfo_Description = table.Column<string>(nullable: true),
                    ProductInfo_ExpirationLocation = table.Column<string>(nullable: true),
                    ProductInfo_OunceWeight = table.Column<int>(nullable: true),
                    ProductInfo_RequiresBubbleWrap = table.Column<bool>(nullable: true),
                    ProductInfo_RequiresPadding = table.Column<bool>(nullable: true),
                    ProductInfo_RequiresBox = table.Column<bool>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelfs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ShelfInfo_Name = table.Column<string>(nullable: true),
                    ShelfInfo_Description = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelfs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wholesalers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    WholesalerInfo_Name = table.Column<string>(nullable: true),
                    WholesalerInfo_Address_Street = table.Column<string>(nullable: true),
                    WholesalerInfo_Address_City = table.Column<string>(nullable: true),
                    WholesalerInfo_Address_ZipCode = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wholesalers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShelfProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ShelfId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Row = table.Column<int>(nullable: false),
                    Column = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelfProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelfProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShelfProduct_Shelfs_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWholesaler",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    WholesalerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWholesaler", x => new { x.ProductId, x.WholesalerId });
                    table.ForeignKey(
                        name: "FK_ProductWholesaler_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWholesaler_Wholesalers_WholesalerId",
                        column: x => x.WholesalerId,
                        principalTable: "Wholesalers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductInfo_Upc",
                table: "Products",
                column: "ProductInfo_Upc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductWholesaler_WholesalerId",
                table: "ProductWholesaler",
                column: "WholesalerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelfProduct_ProductId",
                table: "ShelfProduct",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShelfProduct_ShelfId",
                table: "ShelfProduct",
                column: "ShelfId");

            migrationBuilder.CreateIndex(
                name: "IX_Shelfs_ShelfInfo_Name",
                table: "Shelfs",
                column: "ShelfInfo_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wholesalers_WholesalerInfo_Name",
                table: "Wholesalers",
                column: "WholesalerInfo_Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductWholesaler");

            migrationBuilder.DropTable(
                name: "ShelfProduct");

            migrationBuilder.DropTable(
                name: "Wholesalers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shelfs");
        }
    }
}
