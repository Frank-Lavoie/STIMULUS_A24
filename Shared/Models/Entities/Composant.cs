using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS.Shared.Models.Entities
{
    public class Composant
    {
        public int ComposantId { get; set; }

        public int Ordre { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Type { get; set; }

        [ForeignKey("Reference")]
        public int? ReferenceId { get; set; }
        public Reference? Reference { get; set; }

        [ForeignKey("Page")]
        public int? PageId { get; set; }
        public Page? Page { get; set; }
    }
}
