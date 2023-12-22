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
    public class InscriptionVerification
    {
        [Required(ErrorMessage = "Veuillez entrer un nom")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Veuillez entrer un prénom")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Veuillez entrer une adresse courriel"), DataType(DataType.EmailAddress), EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Veuillez entrer un mot de passe"), DataType(DataType.Password) ]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Veuillez confirmer un mot de passe"), Compare("Password"), DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
