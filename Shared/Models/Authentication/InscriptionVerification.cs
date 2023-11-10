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

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }


        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string? Email { get; set; }


        [Required, DataType(DataType.Password)]
        public string? Password { get; set; }


        [Required, Compare("Password"), DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
        
    }
}
