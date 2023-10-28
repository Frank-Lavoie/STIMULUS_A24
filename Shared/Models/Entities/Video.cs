using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIMULUS.Shared.Models.Entities
{
    public class Video
    {
        public int VideoId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Url { get; set; }
        public int Longueur { get; set; }
        public int Largeur { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }
    }
}
