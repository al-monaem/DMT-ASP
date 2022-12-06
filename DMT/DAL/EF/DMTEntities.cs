using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class DMTEntities : DbContext
    {
        public DbSet<User> Users {get;set;}
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<Refund> Refunds { get; set; }
    }
}
