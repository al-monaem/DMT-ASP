using BLL.DTOs;
using DAL.EF.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminService
    {
        public static bool Delete(string id)
        {
            return DataAccessFactory.AdminDataAccess().Delete(id);
        }

        public static List<TransactionDTO> GetTransactions()
        {
            var data = DataAccessFactory.TransactionDataAccess().GetTransactions();
            var transactions = AutoMapperService<Transaction, TransactionDTO>.MapListWithAllDependency(data);
            return transactions;
        }

        public static List<RevenueDTO> GetRevenues()
        {
            var data = DataAccessFactory.AdminDataAccess().GetRevenues();
            var revenues = AutoMapperService<Revenue, RevenueDTO>.MapListWithAllDependency(data);

            return revenues;
        }

        public static dynamic GetTransactionsCount()
        {
            return DataAccessFactory.AdminDataAccess().GetTransactionsCount();
        }

        public static bool VerifyTicket(string id)
        {
            return DataAccessFactory.AdminDataAccess().VerifyTicket(id);
        }
    }
}
