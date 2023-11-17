using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Entities
{
    public class FichierSource
    {
        public int FichierSourceId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Source { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Nom { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string MiseEnSituation { get; set; }

        [ForeignKey("Exercice")]
        public int? ExerciceId { get; set; }
        public Exercice? Exercice { get; set; }
    }
}
