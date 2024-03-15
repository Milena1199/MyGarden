using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Data.Data.Models
{
    public class GardeningZone//this is the users garden with all the special things for it
    {
        [Key]
        public Guid Id { get; set; }

        public string ClimateZone { get; set; }

        public int HardinessZone { get; set; }

        public string SoilType { get; set; } 

    }
}
