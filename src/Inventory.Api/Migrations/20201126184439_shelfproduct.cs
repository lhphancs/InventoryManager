using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Api.Migrations
{
    public partial class shelfproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "ShelfProduct");

            migrationBuilder.AddColumn<int>(
                name: "Column",
                table: "ShelfProduct",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Column",
                table: "ShelfProduct");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ShelfProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
