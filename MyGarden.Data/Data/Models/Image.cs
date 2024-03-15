using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Data.Data.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get;set; }
        public string Url { get; set; }

        [ForeignKey(nameof(Plant))]
        public Guid PlantId { get; set; }
        public Plant Plant { get; set; }
    }
}
