using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Core.Models
{
    public class AddPlantViewModel
    {
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
    }
}
