using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.EF;

namespace DAL.Repo
{
    internal class TokenRepo : IToken
    {
        DMTEntities db;
        internal TokenRepo()
        {
            db = new DMTEntities();
        }
        public Token Add(Token obj)
        {
            db.Tokens.Add(obj);

            if (db.SaveChanges() > 0)
            {
                var tk = GetByUser(obj.userId);
                return tk;
            }
            return null;
        }

        public Token Get(string token)
        {
            return db.Tokens.Include(t=>t.User).FirstOrDefault(t => t.accessToken.Equals(token));
        }
        public Token GetByUser(string id)
        {
            return db.Tokens.Include(t => t.User).FirstOrDefault(t => t.userId.Equals(id) && t.expired_at==null);
        }

        public Token Update(Token obj)
        {
            var dbtk = Get(obj.accessToken);
            db.Entry(dbtk).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
        public bool Expire(string accessToken)
        {
            var token = Get(accessToken);
            if(token != null)
            {
                token.expired_at = DateTime.Now;
                db.Entry(token).CurrentValues.SetValues(token);
                db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
