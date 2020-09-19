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
                        name: "FK_ProductWholesaler_Wholesalers_WholesalerId",
                        column: x => x.WholesalerId,
                        principalTable: "Wholesalers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShelfProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Row = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelfProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelfProduct_Shelfs_Id",
                        column: x => x.Id,
                        principalTable: "Shelfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    ShelfLocationId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false),
                    WholesalerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ShelfProduct_ShelfLocationId",
                        column: x => x.ShelfLocationId,
                        principalTable: "ShelfProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Wholesalers_WholesalerId",
                        column: x => x.WholesalerId,
                        principalTable: "Wholesalers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShelfLocationId",
                table: "Products",
                column: "ShelfLocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_WholesalerId",
                table: "Products",
                column: "WholesalerId");

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
                column: "ProductId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWholesaler_Products_ProductId",
                table: "ProductWholesaler",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShelfProduct_Products_ProductId",
                table: "ShelfProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShelfProduct_ShelfLocationId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductWholesaler");

            migrationBuilder.DropTable(
                name: "ShelfProduct");

            migrationBuilder.DropTable(
                name: "Shelfs");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Wholesalers");
        }
    }
}
