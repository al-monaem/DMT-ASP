using DAL.EF.Model;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IAdmin AdminDataAccess()
        {
            return new AdminRepo();
        }
        public static IRepo<User, string> UserDataAccess()
        {
            return new UserRepo();
        }
        public static IAuth AuthDataAccess()
        {
            return new UserRepo();
        }
        public static IToken TokenDataAccess()
        {
            return new TokenRepo();
        }
        public static ITransaction TransactionDataAccess()
        {
            return new TransactionRepo();
        }
    }
}
