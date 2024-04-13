using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Data.Data.Models
{
    public class Plant
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }

        public ICollection<Image>? Images { get; set; }

        ICollection<Plant_Category>?Plant_Categories { get; set; }

        [Required]
        public string? HowToPlant { get; set; }// when to plant, depth, spacing
        [Required]
        public string? SeasonsOfInterest { get; set; }
        [Required]
        public string? Characteristics { get; set; }//height, depth of the roots, plant family exc.
        [Required]
        public string? ClimateZone { get; set; }
        [Required]
        public int HardinessZone { get; set; }
        [Required]
        public string? SoilType { get; set; }
        [Required]
        public string? Maintance { get; set; }// PruningNeeds(podrqzvane), Fertilization(torene),special care, sun exposure, watering frequency
        [Required]
        public string? LenghtOfLife { get; set; }
        public decimal? Price { get; set; }
        public string? MoreInfo { get; set; }//history, native, habitat and everything else

        public ICollection<PlantAndStyle>? PlantsAndStyles { get; set;}
        public ICollection<PlantAndDisease>? PlantsAndDiseases { get; set; }
        public ICollection<PestAndPlant>? PestsAndPlants { get; set; }
        public ICollection<Plant_Garden>? Plants_Gardens { get; set; }

    }
}
