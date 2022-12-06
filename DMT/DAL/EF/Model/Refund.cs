using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Refund
    {
        public int id { get; set; }
        [Required]
        [ForeignKey("Ticket")]
        public int ticket_id { get; set; }
        [Required]
        [ForeignKey("Transaction")]
        public int transaction_id { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        [ForeignKey("User")]
        public string user_id { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual Transaction Transaction { get; set; }
        public virtual User User { get; set; }
    }
}
