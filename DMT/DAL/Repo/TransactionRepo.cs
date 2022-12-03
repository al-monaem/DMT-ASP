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

        public Route Get()
        {
            throw new NotImplementedException();
        }

        public List<Ticket> Get(string id)
        {
            List<Transaction> transaction = db.Transactions.Where(x => x.Ticket.status.ToLower().Equals("active")).ToList();
            List<Ticket> ticket = new List<Ticket>();

            foreach(var t in transaction)
            {
                ticket.Add(t.Ticket);
            }
            
            return ticket;
        }
            
        public List<Station> GetStations()
        {
            return db.Stations.ToList();
        }

        public Transaction Update()
        {
            throw new NotImplementedException();
        }

        List<Ticket> ITicket.Get()
        {
            throw new NotImplementedException();
        }

        Transaction ITransaction.Get()
        {
            throw new NotImplementedException();
        }
    }
}
