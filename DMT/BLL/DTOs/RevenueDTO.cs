using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RevenueDTO
    {
        public int id { get; set; }
        public int tickets_sold_app { get; set; }
        public int tickets_sold_manual { get; set; }
        public int revenue_app { get; set; }
        public int revenue_manual { get; set; }
        public DateTime? date { get; set; }
    }
}
