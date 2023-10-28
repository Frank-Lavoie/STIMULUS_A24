using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS.Shared.Models.Entities
{
    public class Cours
    {
        public int CoursId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Description { get; set; }

        [ForeignKey("Groupe")]
        public int? GroupeId { get; set; }
        public Groupe? Groupe { get; set; }

        [ForeignKey("Professeur")]
        public string? ProfesseurId { get; set; }
        public Professeur? Professeur { get; set; }
    }
}
