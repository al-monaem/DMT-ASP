using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string nid { get; set; }
        public string dob { get; set; }
        public int wallet { get; set; }
        public string profilePic { get; set; }
        public string role { get; set; }
        public string resettoken { get; set; }
        public DateTime? registrationDate { get; set; } = DateTime.Now;
    }
}
