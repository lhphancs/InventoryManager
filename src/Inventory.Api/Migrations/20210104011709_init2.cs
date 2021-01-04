using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Api.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shelfs_ShelfProduct_ShelfId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelfs_ShelfProducts_Products_ProductId",
                table: "Shelfs_ShelfProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelfs_ShelfProducts_Shelfs_ShelfId",
                table: "Shelfs_ShelfProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShelfProduct_ShelfId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shelfs_ShelfProducts",
                table: "Shelfs_ShelfProducts");

            migrationBuilder.DropColumn(
                name: "ShelfProduct_Column",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShelfProduct_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShelfProduct_Row",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShelfProduct_ShelfId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Shelfs_ShelfProducts",
                newName: "ShelfProduct");

            migrationBuilder.RenameIndex(
                name: "IX_Shelfs_ShelfProducts_ShelfId",
                table: "ShelfProduct",
                newName: "IX_ShelfProduct_ShelfId");

            migrationBuilder.RenameIndex(
                name: "IX_Shelfs_ShelfProducts_ProductId",
                table: "ShelfProduct",
                newName: "IX_ShelfProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShelfProduct",
                table: "ShelfProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShelfProduct_Products_ProductId",
                table: "ShelfProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShelfProduct_Shelfs_ShelfId",
                table: "ShelfProduct",
                column: "ShelfId",
                principalTable: "Shelfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShelfProduct_Products_ProductId",
                table: "ShelfProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ShelfProduct_Shelfs_ShelfId",
                table: "ShelfProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShelfProduct",
                table: "ShelfProduct");

            migrationBuilder.RenameTable(
                name: "ShelfProduct",
                newName: "Shelfs_ShelfProducts");

            migrationBuilder.RenameIndex(
                name: "IX_ShelfProduct_ShelfId",
                table: "Shelfs_ShelfProducts",
                newName: "IX_Shelfs_ShelfProducts_ShelfId");

            migrationBuilder.RenameIndex(
                name: "IX_ShelfProduct_ProductId",
                table: "Shelfs_ShelfProducts",
                newName: "IX_Shelfs_ShelfProducts_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "ShelfProduct_Column",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShelfProduct_Id",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShelfProduct_Row",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShelfProduct_ShelfId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shelfs_ShelfProducts",
                table: "Shelfs_ShelfProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShelfProduct_ShelfId",
                table: "Products",
                column: "ShelfProduct_ShelfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shelfs_ShelfProduct_ShelfId",
                table: "Products",
                column: "ShelfProduct_ShelfId",
                principalTable: "Shelfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelfs_ShelfProducts_Products_ProductId",
                table: "Shelfs_ShelfProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelfs_ShelfProducts_Shelfs_ShelfId",
                table: "Shelfs_ShelfProducts",
                column: "ShelfId",
                principalTable: "Shelfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
