using DAL.EF;
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
    }
}
