using DAL.EF;
using DAL.EF.Helper;
using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;

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

        public int Register(User user)
        {
            user.password = HashPassword.Hash(user.password);
            db.Users.Add(user);
            return db.SaveChanges();
        }

        public int UpdatePassword(string id, string currentPassword, string newPassword)
        {
            var user = db.Users.FirstOrDefault(u => u.id.Equals(id));

            if(user.password.Equals(HashPassword.Hash(currentPassword)))
            {
                user.password = HashPassword.Hash(newPassword);
                db.Entry(user).CurrentValues.SetValues(user);
                return db.SaveChanges();
            }

            return 0;
        }

        public User Update(User obj)
        {
            var user = db.Users.FirstOrDefault(u => u.id.Equals(obj.id));
            if(user.role == 0)
            {
                obj.id = user.id;
                obj.password = user.password;
                obj.email = user.email;
                obj.role = user.role;
                obj.resettoken = user.resettoken;
                obj.wallet = user.wallet;
                obj.registrationDate = user.registrationDate;
            }
            else if(user.role == 1)
            {
                obj.password = user.password;
                obj.role = user.role;
                obj.resettoken = user.resettoken;
            }
            db.Entry(user).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return user;
        }
    }
}
