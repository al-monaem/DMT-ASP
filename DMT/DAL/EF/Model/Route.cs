using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Route
    {
        public int id { get; set; }
        [Required]
        [ForeignKey("Station1")]
        public string station_1 { get; set; }
        [Required]
        [ForeignKey("Station2")]
        public string station_2 { get; set; }
        [Required]
        public int price { get; set; }

        public virtual Station Station1 { get; set; }
        public virtual Station Station2 { get; set; }
    }
}
