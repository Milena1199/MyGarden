using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGarden.Data.Data.Models
{
    public class Disease
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        public string Image { get; set; }

        public string? Cure { get; set; }

        public string? CureImage { get; set; }

        public ICollection<PlantAndDisease>? PlantsAndDiseases { get; set; }
    }
}
