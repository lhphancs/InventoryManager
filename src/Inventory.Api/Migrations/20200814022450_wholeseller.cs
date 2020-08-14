using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inventory.Api.Migrations
{
    public partial class wholeseller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShelfLocation_Shelf_Id",
                table: "ShelfLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shelf",
                table: "Shelf");

            migrationBuilder.RenameTable(
                name: "Shelf",
                newName: "Shelfs");

            migrationBuilder.AddColumn<int>(
                name: "WholesalerId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Shelfs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Shelfs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shelfs",
                table: "Shelfs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Wholesalers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
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
                name: "IX_Products_WholesalerId",
                table: "Products",
                column: "WholesalerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWholesaler_WholesalerId",
                table: "ProductWholesaler",
                column: "WholesalerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Wholesalers_WholesalerId",
                table: "Products",
                column: "WholesalerId",
                principalTable: "Wholesalers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShelfLocation_Shelfs_Id",
                table: "ShelfLocation",
                column: "Id",
                principalTable: "Shelfs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Wholesalers_WholesalerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShelfLocation_Shelfs_Id",
                table: "ShelfLocation");

            migrationBuilder.DropTable(
                name: "ProductWholesaler");

            migrationBuilder.DropTable(
                name: "Wholesalers");

            migrationBuilder.DropIndex(
                name: "IX_Products_WholesalerId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shelfs",
                table: "Shelfs");

            migrationBuilder.DropColumn(
                name: "WholesalerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Shelfs");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Shelfs");

            migrationBuilder.RenameTable(
                name: "Shelfs",
                newName: "Shelf");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shelf",
                table: "Shelf",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShelfLocation_Shelf_Id",
                table: "ShelfLocation",
                column: "Id",
                principalTable: "Shelf",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
