using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Seun_s_Bank
{
    class Program
    {
        static void Main(string[] args)
        {

            Account acct = new Account(112, "Seun" , "savings");
            Bank bank = new Bank();
            Console.WriteLine(acct.Account_type);
            // Welcome Message
            string choice = "a";
            Console.WriteLine("Welcome to Seun's Bank!");
            do
            {   //handle sign in, sign up or exit the app;
                Console.WriteLine("Press 'a' to sign up, 'b' to sign in or 'q' to exit the application");
                choice = Console.ReadLine();

                //If the customer chooses sign up
                if (choice.Equals("a"))
                {
                    Console.WriteLine("Enter your name below");
                    var inputName = Console.ReadLine();

                }
                else if (choice.Equals("b"))
                {

                }


            } while (choice.Equals("q" ) == false);
        }
    }
}
