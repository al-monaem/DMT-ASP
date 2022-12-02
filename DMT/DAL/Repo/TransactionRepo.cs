using DAL.EF;
using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TransactionRepo : ITransaction
    {
        DMTEntities db;
        internal TransactionRepo()
        {
            db = new DMTEntities();
        }
        public Transaction Add()
        {
            throw new NotImplementedException();
        }

        public Transaction Get()
        {
            throw new NotImplementedException();
        }

        public List<Station> GetStations()
        {
            return db.Stations.ToList();
        }

        public Transaction Update()
        {
            throw new NotImplementedException();
        }

        Ticket ITicket.Get()
        {
            throw new NotImplementedException();
        }

        Route IRoute.Get()
        {
            throw new NotImplementedException();
        }
    }
}
