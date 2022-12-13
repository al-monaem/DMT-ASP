using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PasswordResetDTO
    {
        [Required]
        public string email { get; set; }
        public string otp { get; set; }
        [StringLength(int.MaxValue, MinimumLength =4)]
        public string password { get; set; }
    }
}
