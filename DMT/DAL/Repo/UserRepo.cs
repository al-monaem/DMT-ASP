using DAL.EF;
using DAL.EF.Helper;
using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo : IRepo<User, string>, IAuth
    {
        DMTEntities db;
        internal UserRepo()
        {
            db = new DMTEntities();
        }
        public bool Add(User obj)
        {
            var rs = db.Users.Add(obj);
            return (db.SaveChanges() > 0);
        }

        public User Authenticate(string email, string password)
        {
            string pass = HashPassword.Hash(password);
            return db.Users.FirstOrDefault(x => x.email == email && x.password == pass);
        }

        public bool Delete(string id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(string id)
        {
            return db.Users.Find(id);
        }

        public User Update(User obj)
        {
            var user = db.Users.FirstOrDefault(u => u.id.Equals(obj.id));
            db.Entry(user).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return user;
        }
    }
}
