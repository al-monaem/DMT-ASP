using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StationDTO
    {
        public string id { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
