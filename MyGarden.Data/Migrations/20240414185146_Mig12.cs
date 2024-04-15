using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarden.Data.Migrations
{
    public partial class Mig12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Maintance",
                table: "Plants",
                newName: "Maintenance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Maintenance",
                table: "Plants",
                newName: "Maintance");
        }
    }
}
