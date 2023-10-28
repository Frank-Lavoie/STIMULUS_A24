using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS.Shared.Models.Entities
{
    public class Importance
    {
        [Key]
        [Column(TypeName = "char(3)")]
        public int Code { get; set; }

        public int Pts { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
    }
}
