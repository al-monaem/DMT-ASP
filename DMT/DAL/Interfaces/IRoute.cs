using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRoute
    {
        List<Route> GetRoutes();
        Route GetRoute(int id);
        List<Station> GetStations();
    }
}
