using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAdmin
    {
        bool Delete(string id);
        List<Revenue> GetRevenues();
        dynamic GetTransactionsCount();
        bool VerifyTicket(string transaction_id);
    }
}
