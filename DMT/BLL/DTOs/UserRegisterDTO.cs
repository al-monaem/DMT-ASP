using BLL.Custom_Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        [StringLength(10, MinimumLength = 4)]
        [UniqueUser]
        public string id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string name { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [RegularExpression("^([0-9\\s\\-\\+\\\\]*)$")]
        public string phone { get; set; }
        [StringLength(13, MinimumLength = 13)]
        public string nid { get; set; }
        [Required]
        public DateTime? dob { get; set; }
        public int wallet { get; set; }
        public string profilePic { get; set; }
        public int role { get; set; }
        public string resettoken { get; set; }
        public DateTime? registrationDate { get; set; } = DateTime.Now;
        [Compare("password")]
        public string confirmPassword { get; set; }
        [Required]
        [UniqueEmail]
        public string email { get; set; }
    }
}
