using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Core.Models
{
    public class AddInPestsAndPlantsViewModel
    {
        public Guid PlantId {  get; set; }
        public Guid PestId { get; set; }
    }
}
