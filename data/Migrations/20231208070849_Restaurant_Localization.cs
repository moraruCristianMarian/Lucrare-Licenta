using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    public partial class Restaurant_Localization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Oras",
                table: "Restaurants",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Nume",
                table: "Restaurants",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Restaurants",
                newName: "Nume");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Restaurants",
                newName: "Oras");
        }
    }
}
