using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ValidationEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Email: ");
            var email = Console.ReadLine();
            Email newEmail = new Email();
            var response = newEmail.isValidEmail(email);
        }
    }
}
