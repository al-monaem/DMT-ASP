using BLL.Custom_Validator;
using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class UserDTO
    {
        [Required]
        [StringLength(10, MinimumLength = 4)]
        [UniqueUser]
        public string id { get; set; }
        [Required]
        [StringLength(20, MinimumLength =4)]
        public string name { get; set; }
        [Required]
        public string password { get; set; }
        [Compare("password")]
        public string confirmPassword { get; set; }
        [Required]
        [UniqueEmail]
        public string email { get; set; }
        [Required]
        [RegularExpression("^([0-9\\s\\-\\+\\\\]*)$")]
        public string phone { get; set; }
        [StringLength(13, MinimumLength =13)]
        public string nid { get; set; }
        [Required]
        public DateTime? dob { get; set; }
        public int wallet { get; set; }
        public string profilePic { get; set; }
        public int role { get; set; }
        public string resettoken { get; set; }
        public DateTime? registrationDate { get; set; } = DateTime.Now;
    }
}
