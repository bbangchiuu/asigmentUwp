using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App1.Entity
{
    class Member
    {
        public string id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string avatar { get; set; }

        public string phone { get; set; }

        public string address { get; set; }

        public string introduction { get; set; }

        public int gender { get; set; }

        public string birthday { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public Dictionary<string, string> ValidateData()
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(this.firstName))
            {
                errors.Add("firstname", "First name can not be empty!");
            }
            else
            {
                errors.Remove("firstname");
            }

            if (string.IsNullOrEmpty(this.lastName))
            {
                errors.Add("lastname", "Last name can not be empty!");
            }
            else
            {
                errors.Remove("lastname");
            }

            if (string.IsNullOrEmpty(this.address))
            {
                errors.Add("address", "Address can not be empty!");
            }
            else
            {
                errors.Remove("address");
            }

            if (string.IsNullOrEmpty(this.phone))
            {
                errors.Add("phone", "Phone can not be empty!");
            }
            else
            {
                errors.Remove("phone");
            }

            if (string.IsNullOrEmpty(this.birthday))
            {
                errors.Add("birthday", "Birthday can not be empty!");
            }
            else
            {
                errors.Remove("birthday");
            }

            if (string.IsNullOrEmpty(this.introduction))
            {
                errors.Add("introduction", "Introduction can not be empty!");
            }
            else
            {
                errors.Remove("introduction");
            }

            if (string.IsNullOrEmpty(this.email))
            {
                errors.Add("email", "Email can not be empty!");
            }
            else
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(this.email);
                if (!match.Success)
                {
                    errors.Add("email", "Email is invalid!");
                }
                else
                {
                    errors.Remove("email");
                }
            }

            if (string.IsNullOrEmpty(this.password))
            {
                errors.Add("password", "Password can not be empty!");
            }
            else
            {
                errors.Remove("password");
            }

            return errors;
        }
    }
}
