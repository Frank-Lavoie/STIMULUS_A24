using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Entities
{
    public class Graphe
    {
        public int GrapheId { get; set; }

        [Column(TypeName = "nvarchar(55)")]
        public string Nom { get; set; }

        [Column(TypeName = "varchar(10)")]
        public GrapheStatus Status { get; set; }

        [ForeignKey("Groupe")]
        public int? GroupeId { get; set; }
        public Groupe? Groupe { get; set; }
    }

    public enum GrapheStatus
    {
        ACTIVER,
        DESACTIVER
    }
}
