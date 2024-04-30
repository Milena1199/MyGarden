using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MyGarden.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Core.Models
{
    public class UpdatePlantViewModel
    {
        public Guid PlantId { get; set; }
        public string Name { get; set; }
        public string HowToPlant { get; set; }
        public string SeasonOfInteret { get; set; }
        public string Characteristics { get; set; }
        public string ClimateZone { get; set; }
        public int HardinessZone { get; set; }
        public string SoilType { get; set; }
        public string Мaintenance { get; set; }
        public string LenghtOfLife { get; set; }
        public decimal Price { get; set; }
        public string MoreInfo { get; set; }


        public List<string> Categories { get; set; }
        public List<string> Images { get; set; }
        public List<string> Diseases { get; set; }
        public List<string> Pests { get; set; }
        public List<string> Styles { get; set; }

        public int Index { get; set; }
    }
}
