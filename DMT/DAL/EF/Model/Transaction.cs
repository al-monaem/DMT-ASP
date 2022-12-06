using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Transaction
    {
        public int id { get; set; }
        public string status { get; set; } = "PAID";
        public DateTime? date { get; set; } = DateTime.Now;
        [Required]
        [StringLength(20)]
        public string method { get; set; }
        [Required]
        [ForeignKey("User")]
        public string user_id { get; set; }
        [Required]
        [ForeignKey("Ticket")]
        public int ticket_id { get; set; }
        [Required]
        public string transaction_id { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual User User { get; set; }
    }
}
