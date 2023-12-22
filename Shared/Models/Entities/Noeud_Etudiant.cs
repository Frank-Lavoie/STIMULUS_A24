using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Entities
{
    public class Noeud_Etudiant
    {
        public int Noeud_EtudiantId { get; set; }

        public int? Status { get; set; }

        [ForeignKey("Etudiant")]
        public string? CodeDA { get; set; }

        public Etudiant? Etudiant { get; set; }

        [ForeignKey("Noeud")]
        public int? NoeudId { get; set; }

        public Noeud? Noeud { get; set; }
    }
}
