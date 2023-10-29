using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Entities
{
    public class Page
    {
        public int PageId { get; set; }
        public int Ordre { get; set; }

        [ForeignKey("Noeud")]
        public int? NoeudId { get; set; }
        public Noeud? Noeud { get; set; }

        [ForeignKey("Importance")]
        public int? ImportanceId { get; set; }
        public Importance? Importance { get; set; }

    }
}
