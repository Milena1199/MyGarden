using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarden.Data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GardeningZones_Users_GuidId",
                table: "GardeningZones");

            migrationBuilder.RenameColumn(
                name: "GuidId",
                table: "GardeningZones",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GardeningZones_GuidId",
                table: "GardeningZones",
                newName: "IX_GardeningZones_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Diseases",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_GardeningZones_Users_UserId",
                table: "GardeningZones",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GardeningZones_Users_UserId",
                table: "GardeningZones");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "GardeningZones",
                newName: "GuidId");

            migrationBuilder.RenameIndex(
                name: "IX_GardeningZones_UserId",
                table: "GardeningZones",
                newName: "IX_GardeningZones_GuidId");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Diseases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GardeningZones_Users_GuidId",
                table: "GardeningZones",
                column: "GuidId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
