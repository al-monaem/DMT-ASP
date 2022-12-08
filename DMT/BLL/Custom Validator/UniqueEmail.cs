using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Custom_Validator
{
    internal class UniqueEmail : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var users = UserService.Get();

            foreach (var user in users)
            {
                if (user.email.Equals(value))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
