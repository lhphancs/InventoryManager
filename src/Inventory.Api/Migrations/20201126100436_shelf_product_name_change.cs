using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Api.Migrations
{
    public partial class shelf_product_name_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShelfProduct_ShelfLocationId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShelfProduct_Products_ProductId",
                table: "ShelfProduct");

            migrationBuilder.DropIndex(
                name: "IX_ShelfProduct_ProductId",
                table: "ShelfProduct");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShelfLocationId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShelfLocationId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "ShelfProduct",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShelfProductId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShelfProduct_ProductId1",
                table: "ShelfProduct",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShelfProductId",
                table: "Products",
                column: "ShelfProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShelfProduct_ShelfProductId",
                table: "Products",
                column: "ShelfProductId",
                principalTable: "ShelfProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShelfProduct_Products_ProductId1",
                table: "ShelfProduct",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShelfProduct_ShelfProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShelfProduct_Products_ProductId1",
                table: "ShelfProduct");

            migrationBuilder.DropIndex(
                name: "IX_ShelfProduct_ProductId1",
                table: "ShelfProduct");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShelfProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ShelfProduct");

            migrationBuilder.DropColumn(
                name: "ShelfProductId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ShelfLocationId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShelfProduct_ProductId",
                table: "ShelfProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShelfLocationId",
                table: "Products",
                column: "ShelfLocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShelfProduct_ShelfLocationId",
                table: "Products",
                column: "ShelfLocationId",
                principalTable: "ShelfProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShelfProduct_Products_ProductId",
                table: "ShelfProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
