using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductStore.Data.Migrations
{
    public partial class ComplexType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "products",
                newName: "Address_StreetAddress");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "products",
                newName: "Address_City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_StreetAddress",
                table: "products",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "products",
                newName: "City");
        }
    }
}
