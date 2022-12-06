using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Ticket
    {
        public Ticket()
        {
            this.Refunds = new List<Refund>();
            this.Transactions = new List<Transaction>();
        }

        public int id { get; set; }

        [Required]
        [ForeignKey("Route")]
        public int route_id { get; set; }
        public string status { get; set; } = "Active";

        public virtual Route Route { get; set; }
        public virtual List<Refund> Refunds { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}
