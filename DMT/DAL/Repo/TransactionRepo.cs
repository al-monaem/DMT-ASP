using DAL.EF;
using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
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
            return db.Transactions.Include(u=>u.User).ToList();
        }

        List<Ticket> ITicket.GetTickets()
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetTransactions(string userId)
        {
            return db.Transactions.Where(x=>x.user_id.Equals(userId)).ToList();
        }

        public Transaction Checkout(string user_id, int route_id, string paymentMethod, int price)
        {
            var user = db.Users.Find(user_id);

            if (user == null || user.wallet < price)
            {
                return null;
            }
            if (paymentMethod.Equals("wallet"))
            {
                //db.Entry(user).State = EntityState.Modified;
                user.wallet -= price;
                //db.Entry(user).CurrentValues.SetValues(user);
                db.SaveChanges();

                var ticket = new Ticket() { route_id = route_id };
                db.Tickets.Add(ticket);
                db.SaveChanges();

                ticket = GetTicketByRouteId(route_id);

                var transaction = new Transaction()
                {
                    method = paymentMethod,
                    status = "paid",
                    user_id = user_id,
                    ticket_id = ticket.id,
                    transaction_id = "WLT_" + Guid.NewGuid().ToString()
                };

                db.Transactions.Add(transaction);
                db.SaveChanges();

                transaction = GetTransactionByTicketId(ticket.id);

                return transaction;
            }
            else if (paymentMethod.Equals("gateway"))
            {
                var ticket = new Ticket() { route_id = route_id };
                db.Tickets.Add(ticket);
                db.SaveChanges();

                ticket = GetTicketByRouteId(route_id);

                var transaction = new Transaction()
                {
                    method = paymentMethod,
                    status = "paid",
                    user_id = user_id,
                    ticket_id = ticket.id,
                    transaction_id = "WLT_" + Guid.NewGuid().ToString()
                };

                db.Transactions.Add(transaction);
                db.SaveChanges();

                transaction = GetTransactionByTicketId(ticket.id);

                var url = "https://sandbox.aamarpay.com/request.php";
                Dictionary<string, string> fields = new Dictionary<string, string>();
                fields["store_id"] = "aamarpaytest";
                fields["amount"] =price.ToString();
                fields["payment_type"] = "VISA";
                fields["currency"] = "BDT";
                fields["tran_id"] =transaction.transaction_id;
                fields["cus_name"] = "NA";
                fields["cus_email"] = "NA@mail.com";
                fields["cus_add1"] = "Dhaka";
                fields["cus_add2"] = "NA";
                fields["cus_city"] = "Dhaka";
                fields["cus_state"] = "Dhaka";
                fields["cus_postcode"] = "1206";
                fields["cus_country"] = "Bangladesh";
                fields["cus_phone"] = "1231231231231";
                fields["cus_fax"] = "Not¬Applicable";
                fields["ship_name"] = "ship name";
                fields["ship_add1"] = "NA";
                fields["ship_add2"] = "NA";
                fields["ship_city"] = "Dhaka";
                fields["ship_state"] = "Dhaka";
                fields["opt_a"] =transaction.ticket_id.ToString();
                fields["opt_b"] =user_id;
                fields["ship_postcode"] = "1212";
                fields["ship_country"] = "Bangladesh";
                fields["desc"] = "description";
                fields["success_url"] = "https://localhost:44361/api/success";
                fields["fail_url"] = "https://localhost:44361/api/fail";
                fields["cancel_url"] = "http://localhost/amarpay/api/cancel.php";
                fields["signature_key"] = "dbb74894e82415a2f7ff0ec3a97e4183";

            }

            return null;
        }

        public Transaction GetTransactionByTicketId(int id)
        {
            return db.Transactions.FirstOrDefault(t => t.ticket_id == id);
        }

        public Ticket GetTicketByRouteId(int id)
        {
            return db.Tickets.FirstOrDefault(t => t.route_id == id);
        }
    }
}
