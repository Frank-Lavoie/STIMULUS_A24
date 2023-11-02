using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Entities
{
    public class Etudiant
    {
        [Key]
        [Column(TypeName = "nvarchar(255)")]
        public string CodeDA { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string Nom { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string Prenom { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? MotDePasse { get; set; }
    }
}
