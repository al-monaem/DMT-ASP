using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITicket
    {
        List<Ticket> GetTickets();
        List<Ticket> GetTickets(string id);
    }
}
