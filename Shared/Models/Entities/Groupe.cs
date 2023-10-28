using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS.Shared.Models.Entities
{
    public class Groupe
    {
        public int GroupeId { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Nom { get; set; }
    }
}
