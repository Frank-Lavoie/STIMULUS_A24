using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS.Shared.Models.Entities
{
    public class Groupe_Etudiant
    {
        public int Groupe_EtudiantId { get; set; }

        [ForeignKey("Groupe")]
        public int? GroupeId { get; set; }
        public Groupe? Groupe { get; set; }

        [ForeignKey("Etudiant")]
        public string? CodeDA { get; set; }
        public Etudiant? Etudiant { get; set; }
    }
}
