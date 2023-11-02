using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Entities
{
    public class Groupe
    {
        public int GroupeId { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Nom { get; set; }

        [ForeignKey("Cours")]
        public int? CoursId { get; set; }
        public Cours? Cours { get; set; }

        [ForeignKey("Professeur")]
        public string? ProfesseurId { get; set; }
        public Professeur? Professeur { get; set; }
    }
}
