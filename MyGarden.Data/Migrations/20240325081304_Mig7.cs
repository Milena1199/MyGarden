using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGarden.Data.Migrations
{
    public partial class Mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CureImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GardenStyles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CureImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HowToPlant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeasonsOfInterest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Characteristics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClimateZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HardinessZone = table.Column<int>(type: "int", nullable: false),
                    SoilType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maintance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LenghtOfLife = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoreInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GardeningZones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClimateZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HardinessZone = table.Column<int>(type: "int", nullable: false),
                    SoilType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardeningZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GardeningZones_Users_GuidId",
                        column: x => x.GuidId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PestsAndPlants",
                columns: table => new
                {
                    PestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PestsAndPlants", x => new { x.PestId, x.PlantId });
                    table.ForeignKey(
                        name: "FK_PestsAndPlants_Pests_PestId",
                        column: x => x.PestId,
                        principalTable: "Pests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PestsAndPlants_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantsAndDiseases",
                columns: table => new
                {
                    PlantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiseaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantsAndDiseases", x => new { x.PlantId, x.DiseaseId });
                    table.ForeignKey(
                        name: "FK_PlantsAndDiseases_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantsAndDiseases_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantsAndStyles",
                columns: table => new
                {
                    PlantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StyleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GardenStyleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantsAndStyles", x => new { x.PlantId, x.StyleId });
                    table.ForeignKey(
                        name: "FK_PlantsAndStyles_GardenStyles_GardenStyleId",
                        column: x => x.GardenStyleId,
                        principalTable: "GardenStyles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlantsAndStyles_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plants_Gardens",
                columns: table => new
                {
                    PlantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersGardenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants_Gardens", x => new { x.PlantId, x.UsersGardenId });
                    table.ForeignKey(
                        name: "FK_Plants_Gardens_GardeningZones_UsersGardenId",
                        column: x => x.UsersGardenId,
                        principalTable: "GardeningZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_Gardens_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardeningZones_GuidId",
                table: "GardeningZones",
                column: "GuidId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PlantId",
                table: "Images",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PestsAndPlants_PlantId",
                table: "PestsAndPlants",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_TypeId",
                table: "Plants",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_Gardens_UsersGardenId",
                table: "Plants_Gardens",
                column: "UsersGardenId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantsAndDiseases_DiseaseId",
                table: "PlantsAndDiseases",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantsAndStyles_GardenStyleId",
                table: "PlantsAndStyles",
                column: "GardenStyleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "PestsAndPlants");

            migrationBuilder.DropTable(
                name: "Plants_Gardens");

            migrationBuilder.DropTable(
                name: "PlantsAndDiseases");

            migrationBuilder.DropTable(
                name: "PlantsAndStyles");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Pests");

            migrationBuilder.DropTable(
                name: "GardeningZones");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "GardenStyles");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
