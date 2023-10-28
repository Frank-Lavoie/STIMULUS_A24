using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS.Shared.Models.Entities
{
    public class Code
    {
        public int CodeId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Contenue { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Titre { get; set; }
    }
}
