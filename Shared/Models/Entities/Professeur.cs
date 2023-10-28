using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS.Shared.Models.Entities
{
    public class Professeur
    {
        [Key]
        [Column(TypeName = "nvarchar(255)")]
        public string NumEmploye { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Nom { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Prenom { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MotDePasse { get; set; }
    }
}
