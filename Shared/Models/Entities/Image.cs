using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS_V2.Shared.Models.Entities
{
    public class Image
    {
        public int ImageId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string url { get; set; }
        public int Longueur { get; set; }
        public int Largeur { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }

    }
}
