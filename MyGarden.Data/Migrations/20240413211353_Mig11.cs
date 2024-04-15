using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarden.Data.Migrations
{
    public partial class Mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_PlantTypes_TypeId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Gardens_GardeningZones_UsersGardenId",
                table: "Plants_Gardens");

            migrationBuilder.DropTable(
                name: "PlantTypes");

            migrationBuilder.DropIndex(
                name: "IX_Plants_TypeId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Plants");

            migrationBuilder.RenameColumn(
                name: "UsersGardenId",
                table: "Plants_Gardens",
                newName: "GardeningZoneId");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_Gardens_UsersGardenId",
                table: "Plants_Gardens",
                newName: "IX_Plants_Gardens_GardeningZoneId");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants_Categories",
                columns: table => new
                {
                    PlantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants_Categories", x => new { x.PlantId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_Plants_Categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_Categories_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_Categories_CategoryId",
                table: "Plants_Categories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Gardens_GardeningZones_GardeningZoneId",
                table: "Plants_Gardens",
                column: "GardeningZoneId",
                principalTable: "GardeningZones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Gardens_GardeningZones_GardeningZoneId",
                table: "Plants_Gardens");

            migrationBuilder.DropTable(
                name: "Plants_Categories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.RenameColumn(
                name: "GardeningZoneId",
                table: "Plants_Gardens",
                newName: "UsersGardenId");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_Gardens_GardeningZoneId",
                table: "Plants_Gardens",
                newName: "IX_Plants_Gardens_UsersGardenId");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Plants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PlantTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_TypeId",
                table: "Plants",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_PlantTypes_TypeId",
                table: "Plants",
                column: "TypeId",
                principalTable: "PlantTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Gardens_GardeningZones_UsersGardenId",
                table: "Plants_Gardens",
                column: "UsersGardenId",
                principalTable: "GardeningZones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
