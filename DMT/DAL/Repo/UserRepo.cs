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
        public User GetByEmail(string email)
        {
            return db.Users.FirstOrDefault(x=>x.email.Equals(email));
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

        public User Update(User obj, string token)
        {
            var tk = GetUserByToken(token).User;

            var user = db.Users.FirstOrDefault(u => u.id.Equals(obj.id));
            user.password = obj.password;
            user.nid = obj.nid;
            user.dob = obj.dob;
            if(tk.role == 1)
            {
                user.role = obj.role;
                user.email = obj.email;
            }
            db.SaveChanges();
            return user;
        }

        public Token GetUserByToken(string id)
        {
            return db.Tokens.FirstOrDefault(t=>t.accessToken == id);
        }

        public dynamic ResetPassword(string email, string otp, string password)
        {
            var user = GetByEmail(email);
            if (user == null)
            {
                return false;
            }

            if (otp.Equals(""))
            {
                Random RandNum = new Random();
                int RandomNumber = RandNum.Next(10000, 99999);

                var reset = new Reset()
                {
                    OTP = RandomNumber,
                    user_id = user.id,
                };
                db.Resets.Add(reset);
                db.SaveChanges();
                return reset;
            }
            else
            {
                var data = db.Resets.FirstOrDefault(x => x.OTP.ToString().Equals(otp) && x.expiresAt < DateTime.Now);
                if (data == null)
                {
                    return false;
                }
                user.password = HashPassword.Hash(password);
                db.SaveChanges();

                return true;
            }

        }
    }
}
