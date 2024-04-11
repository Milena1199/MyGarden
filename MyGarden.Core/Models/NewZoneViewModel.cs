using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Core.Models
{
    public class NewZoneViewModel
    {
        public Guid Id { get; set; }
        public string ClimateZone { get; set; }
        public int HardinessZone {  get; set; }
        public string SoilType { get; set; }
    }
}
