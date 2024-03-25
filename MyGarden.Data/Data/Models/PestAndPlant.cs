using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Data.Data.Models
{
    public class PestAndPlant
    {
        public Guid PestId { get; set; }
        public Pest? Pest { get; set; }

        public Guid PlantId {get;set;}
        public Plant? Plant { get; set; }
    }
}
