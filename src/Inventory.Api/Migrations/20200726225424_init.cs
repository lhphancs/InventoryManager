using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shelf",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
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
                    Id = table.Column<byte[]>(nullable: false),
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
                    Upc = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExpirationLocation = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    OunceWeight = table.Column<int>(nullable: false),
                    RequiresPadding = table.Column<bool>(nullable: false),
                    RequiresBubbleWrap = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ShelfLocationId = table.Column<byte[]>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Upc);
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
