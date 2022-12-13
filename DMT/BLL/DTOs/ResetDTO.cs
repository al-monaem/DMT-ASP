using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ResetDTO
    {
        public int id { get; set; }
        public int OTP { get; set; }
        public DateTime issuedAt { get; set; } = DateTime.Now;
        public DateTime expiresAt { get; set; } = DateTime.Now.AddMinutes(5);
        public string user_id { get; set; }

        public virtual User User { get; set; }
    }
}
