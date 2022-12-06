using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Token
    {
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string accessToken { get; set; }
        [Required]
        [ForeignKey("User")]
        public string userId { get; set; }
        public System.DateTime? created_at { get; set; } = DateTime.Now;
        public Nullable<System.DateTime> expired_at { get; set; }

        public virtual User User { get; set; }
    }
}
