using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Core.Models
{
    public class UpdateZoneViewModel
    {
        public Guid id { get; set; }
        public string ClimateZone { get; set; }
        public int HardinessZone { get; set; }
        public string SoilType { get; set; }
    }
}
