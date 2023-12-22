using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Entities
{
    public class TexteFormater
    {
        public int TexteFormaterId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? Contenue { get; set; }
    }
}
