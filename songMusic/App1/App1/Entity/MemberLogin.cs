using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Entity
{
    class MemberLogin
    {
        public string email { get; set; }
        public string password { get; set; }
        public Dictionary<string, string> ValidateData()
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(this.email))
            {
                errors.Add("email", "Email is required!");
            }
            else
            {
                errors.Remove("email");
            }

            if (string.IsNullOrEmpty(this.password))
            {
                errors.Add("password", "Password is required!");
            }
            else
            {
                errors.Remove("password");
            }

            return errors;
        }
    }
}
