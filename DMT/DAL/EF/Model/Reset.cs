using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Reset
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int OTP { get; set; }
        [Required]
        public DateTime issuedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime expiresAt { get; set; } = DateTime.Now.AddMinutes(5);
        [Required]
        [ForeignKey("User")]
        public string user_id { get; set; }

        public virtual User User { get; set; }
    }
}
