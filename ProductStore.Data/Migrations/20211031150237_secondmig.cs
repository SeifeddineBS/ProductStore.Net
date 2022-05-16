using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductStore.Data.Migrations
{
    public partial class secondmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "products",
                newName: "ImageURL2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL2",
                table: "products",
                newName: "ImageURL");
        }
    }
}
