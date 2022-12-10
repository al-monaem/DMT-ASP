using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class GatewayDTO
    {
        public int route_id { get; set; }
        public string user_id { get; set; }
        public string paymentMethod { get; set; }
        public int price { get; set; }
    }
}
