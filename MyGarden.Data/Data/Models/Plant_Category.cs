using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Data.Data.Models
{
    public class Plant_Category
    {
        public Guid PlantId { get; set; }
        public Plant Plant { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
