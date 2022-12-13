using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PasswordChangeDTO
    {
        public string id { get; set; }
        public string currentPassword { get; set; }
        public string newPassword { get; set; }
    }
}
