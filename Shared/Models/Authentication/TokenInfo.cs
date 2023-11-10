using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Authentication
{
    public class TokenInfo
    {
        public int TokenInfoId { get; set; }

        public string UserId { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? TokenExpiry { get; set; }
    }
}
