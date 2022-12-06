using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class User
    {
        public User()
        {
            this.Refunds = new List<Refund>();
            this.Tokens = new List<Token>();
            this.Transactions = new List<Transaction>();
        }
        [Key]
        public string id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [Index(IsUnique =true)]
        [StringLength(100)]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
        public string nid { get; set; }
        public Nullable<DateTime> dob { get; set; }
        public int wallet { get; set; }
        public string profilePic { get; set; }
        public int role { get; set; }
        public string resettoken { get; set; }
        public DateTime? registrationDate { get; set; } = DateTime.Now;

        public virtual List<Refund> Refunds { get; set; }
        public virtual List<Token> Tokens { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}
