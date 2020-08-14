using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Api.Migrations
{
    public partial class wholeseller2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Wholesalers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Wholesalers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                table: "Wholesalers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Wholesalers");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Wholesalers");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                table: "Wholesalers");
        }
    }
}
