using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Authentication
{
    public class ConnexionVerification
    {
        [Required]
        public string? Identifiant { get; set; }

        [Required, DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
