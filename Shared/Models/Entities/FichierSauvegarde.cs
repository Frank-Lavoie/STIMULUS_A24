using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Entities
{
    public class FichierSauvegarde
    {
        public int FichierSauvegardeId { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Nom { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? Contenue { get; set; }

        public DateTime Version { get; set; } = DateTime.Now;

        [ForeignKey("Etudiant")]
        public string? CodeDA { get; set; }
        public Etudiant? Etudiant { get; set; }

        [ForeignKey("Exercicre")]
        public int? ExerciceId { get; set; }
        public Exercice? Exercice { get; set; }
   
    }
}
