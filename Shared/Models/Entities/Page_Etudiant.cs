using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS.Shared.Models.Entities
{
    public class Page_Etudiant
    {
        public int Page_EtudiantId { get; set; }

        [ForeignKey("Page")]
        public int? PageId { get; set; }
        public Page? Page { get; set; }

        [ForeignKey("Etudiant")]
        public string? CodeDA { get; set; }
        public Etudiant? Etudiant { get; set; }

        public int Pts { get; set; }
    }
}
