using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Data.Data.Models
{
    public class PlantType
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Plant>? Plants { get; set; }
    }
}
