using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Core.Models
{
    public class AddImageForPlantViewModel
    {
        public string Url { get; set; }
        public Guid PlantId { get; set; }
    }
}
