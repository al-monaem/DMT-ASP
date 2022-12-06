using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TicketDetails : TicketDTO
    {
        List<TransactionDTO> transactionList;
        List<TicketDTO> ticketList;

        public TicketDetails()
        {
            transactionList = new List<TransactionDTO>();
        }
    }
}
