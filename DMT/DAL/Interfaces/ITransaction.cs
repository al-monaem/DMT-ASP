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
        Transaction Update();
        Transaction Add();
    }
}
