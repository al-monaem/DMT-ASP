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

        public List<Route> GetRoutes()
        {
            return db.Routes.ToList();
        }

        public Route GetRoute(int id)
        {
            return db.Routes.Find(id);
        }

        public List<Ticket> GetTickets(string id)
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

        List<Transaction> ITransaction.GetTransactions()
        {
            return db.Transactions.ToList();
        }

        List<Ticket> ITicket.GetTickets()
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetTransactions(string userId)
        {
            return db.Transactions.Where(x=>x.user_id.Equals(userId)).ToList();
        }
    }
}
