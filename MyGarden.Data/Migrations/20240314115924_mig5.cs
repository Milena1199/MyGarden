using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGarden.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Cure = table.Column<string>(nullable: true),
                    CureImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GardeningZones",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClimateZone = table.Column<string>(nullable: true),
                    HardinessZone = table.Column<int>(nullable: false),
                    SoilType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardeningZones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GardenStyles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Cure = table.Column<string>(nullable: true),
                    CureImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    TypeId = table.Column<Guid>(nullable: false),
                    HowToPlant = table.Column<string>(nullable: false),
                    SeasonsOfInterest = table.Column<string>(nullable: false),
                    Characteristics = table.Column<string>(nullable: false),
                    ClimateZone = table.Column<string>(nullable: false),
                    HardinessZone = table.Column<int>(nullable: false),
                    SoilType = table.Column<string>(nullable: false),
                    Maintance = table.Column<string>(nullable: false),
                    LenghtOfLife = table.Column<string>(nullable: false),
                    MoreInfo = table.Column<string>(nullable: true)
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
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    PlantId = table.Column<Guid>(nullable: false)
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
                    PestId = table.Column<Guid>(nullable: false),
                    PlantId = table.Column<Guid>(nullable: false)
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
                    PlantId = table.Column<Guid>(nullable: false),
                    DiseaseId = table.Column<Guid>(nullable: false)
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
                    PlantId = table.Column<Guid>(nullable: false),
                    StyleId = table.Column<Guid>(nullable: false),
                    GardenStyleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantsAndStyles", x => new { x.PlantId, x.StyleId });
                    table.ForeignKey(
                        name: "FK_PlantsAndStyles_GardenStyles_GardenStyleId",
                        column: x => x.GardenStyleId,
                        principalTable: "GardenStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantsAndStyles_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "GardeningZones");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "PestsAndPlants");

            migrationBuilder.DropTable(
                name: "PlantsAndDiseases");

            migrationBuilder.DropTable(
                name: "PlantsAndStyles");

            migrationBuilder.DropTable(
                name: "Pests");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "GardenStyles");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
