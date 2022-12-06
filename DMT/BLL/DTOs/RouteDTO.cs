using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RouteDTO
    {
        public int id { get; set; }
        public string station_1 { get; set; }
        public string station_2 { get; set; }
        public int price { get; set; }

        public virtual Station Station1 { get; set; }
        public virtual Station Station2 { get; set; }
    }
}
