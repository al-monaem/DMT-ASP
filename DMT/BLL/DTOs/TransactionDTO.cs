using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TransactionDTO
    {
        public int id { get; set; }
        public string status { get; set; } = "PAID";
        public DateTime date { get; set; } = DateTime.Now;
        public string method { get; set; }
        public string user_id { get; set; }
        public int ticket_id { get; set; }
        public string transaction_id { get; set; }

        public virtual TicketDTO Ticket { get;set; }
        public virtual UserDTO User { get; set; }
    }
}
