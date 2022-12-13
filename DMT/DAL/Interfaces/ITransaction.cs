using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITransaction: ITicket, IRoute
    {
        List<Transaction> GetTransactions();
        List<Transaction> GetTransactions(string userId);
        Transaction GetTransactionByTicketId(int id);
        bool Refund(int id);
        Transaction Update();
        Transaction Add();
        Transaction Checkout(string user_id, int route_id, string paymentMethod, int price);
    }
}
