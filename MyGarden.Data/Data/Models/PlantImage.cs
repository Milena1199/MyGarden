using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Data.Data.Models
{
    public class PlantImage
    {
        [Key]
        public Guid Id { get;set; }
        public string? Url { get; set; }
        public bool IsVisible { get;set; }

        [ForeignKey(nameof(Plant))]
        public Guid PlantId { get; set; }
        public Plant? Plant { get; set; }
    }
}
