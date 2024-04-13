using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Data.Data.Models
{
    public class Plant_Garden
    {
        public Guid PlantId { get; set; }
        public Plant? Plant { get; set; }

        public Guid GardeningZoneId {  get; set; }
        public GardeningZone? GardeningZone { get; set; }
    }
}
