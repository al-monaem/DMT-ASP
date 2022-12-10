using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAuth
    {
        User Authenticate(string email, string password);
        int Register(User user);
        int UpdatePassword(string id, string currentaPassword, string newPassword);
        Token GetUserByToken(string id);
    }
}
