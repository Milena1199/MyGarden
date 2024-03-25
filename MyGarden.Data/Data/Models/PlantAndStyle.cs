using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Data.Data.Models
{
    public class PlantAndStyle
    {
        public Guid PlantId { get; set; }
        public Plant? Plant { get; set; }
        public Guid StyleId { get; set; }
        public GardenStyle? GardenStyle { get;set; }
    }
}
