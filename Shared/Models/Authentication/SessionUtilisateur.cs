using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Authentication
{
    public class SessionUtilisateur
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
