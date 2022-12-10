using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS, PARAM>
    {
        List<CLASS> Get();
        CLASS Get(PARAM id);
        CLASS Update(CLASS obj, string token);
        bool Delete(PARAM id);
        bool Add(CLASS obj);
    }
}
