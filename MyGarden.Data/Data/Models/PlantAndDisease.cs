using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Data.Data.Models
{
    public class PlantAndDisease
    {
        public Guid PlantId { get; set; }
        public Plant Plant { get; set; }

        public Guid DiseaseId { get; set; }
        public Disease Disease { get; set; }
    }
}
