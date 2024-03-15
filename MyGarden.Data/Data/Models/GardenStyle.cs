using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Data.Data.Models
{
    public class GardenStyle
    {
        [Key]
        public Guid Id { get;set; }
        [Required]
        public string Name { get;set; }
        [Required]
        public string Description { get;set; }
        public string Image { get; set; }

        public ICollection<PlantAndStyle>PlantsAndStyles { get; set; }
    }
}
