using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS.Shared.Models.Entities
{
    public class FichierSauvegarde
    {
        public int FichierSauvegardeId { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Nom { get; set; }

        [Column(TypeName = "varchar(8000)")]
        public string? Contenue { get; set; }
        public DateTime Version { get; set; } = DateTime.Now;

        [ForeignKey("Page_Etudiant")]
        public int? Page_EtudiantId { get; set; }
        public Page_Etudiant? Page_Etudiant { get; set; }

        

    }
}
