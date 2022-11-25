using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {
        public int id { get; set; }
        public string accessToken { get; set; }
        public string userId { get; set; }
        public System.DateTime created_at { get; set; }
        public Nullable<System.DateTime> expired_at { get; set; }
    }
}
