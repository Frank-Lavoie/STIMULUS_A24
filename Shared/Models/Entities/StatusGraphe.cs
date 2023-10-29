using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Entities
{
    public class StatusGraphe
    {
        [Key]
        [Column(TypeName = "char(3)")]
        public string Code { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Nom { get; set; }
    }
}
