using STIMULUS_V2.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Authentication
{
    public class Utilisateur
    {

        [Key]
        [Column(TypeName = "nvarchar(255)")]
        public string Identifiant { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string? Email { get; set; }

        public string? MotDePasse { get; set; }

        public string Role { get; set; }

    } 
}
