using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Entities
{
    public class LienUtile
    {
        public int LienUtileId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Url { get; set; }

        [ForeignKey("Graphe")]
        public int? GrapheId { get; set; }
        public Graphe? Graphe { get; set; }
    }
}
