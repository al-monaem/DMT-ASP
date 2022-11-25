using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IToken
    {
        Token Get(string token);
        Token GetByUser(string id);
        Token Update(Token obj);
        Token Add(Token obj);
    }
}
