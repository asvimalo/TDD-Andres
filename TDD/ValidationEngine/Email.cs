using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidationEngine
{
    public class Email
    {
        

        public bool isValidEmail(string email)
        {
            
            string _expression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            string expression = @"^(?("")("".+?(?<!\\)""@)|(([a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([a-z][-\w]*[a-z]*\.)+[a-z][\-a-z]{0,22}[a-z]))$";

            if (String.IsNullOrEmpty(email))
                return false;

            try
            {
                return Regex.IsMatch(email, expression);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
