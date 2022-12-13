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
    public class AdminRepo : IAdmin
    {
        DMTEntities db;
        internal AdminRepo()
        {
            db = new DMTEntities();
        }
        public bool Delete(string id)
        {
            var user = db.Users.Find(id);
            if(user == null)
            {
                return false;
            }
            db.Users.Remove(user);
            return db.SaveChanges() > 0;
        }

        public List<Revenue> GetRevenues()
        {
            var revenueData = db.Revenues.OrderBy(u=>u.date).ToList();
            return revenueData;
        }

        public dynamic GetTransactionsCount()
        {
            //var transactions = db.Transactions.ToList();
            var count = from tr in db.Transactions
                        join t in db.Tickets on tr.ticket_id equals t.id
                        join r in db.Routes on t.route_id equals r.id
                        orderby tr.date
                        group tr by tr.date into grp
                        select new
                        {
                            date = grp.Key,
                            amount = grp.Sum(x=>x.Ticket.Route.price)
                        };

            return count;
        }

        public bool VerifyTicket(string transaction_id)
        {
            var transaction = db.Transactions.FirstOrDefault(t => t.transaction_id == transaction_id && t.Ticket.status.ToLower().Equals("active"));
            if (transaction == null)
                return false;

            transaction.Ticket.status = "used";
            db.SaveChanges();

            return true;
        }
    }
}
