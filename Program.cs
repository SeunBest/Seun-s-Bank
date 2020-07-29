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
                    Console.WriteLine("Enter your email below");
                    var inputMail = Console.ReadLine();
                    Console.WriteLine("Enter your Password below");
                    var inputPass = Console.ReadLine();

                    //Initiallize customer
                    var person = new Customer(inputName, inputMail, inputPass);

                    //Add Customer to list
                    bank.AddCustomer(person);
                    Console.WriteLine($"Customer {person.Name}, with email {person.Email} has been created");

                    //Introduce user to menu
                    do
                    {
                        Console.WriteLine("Press 'c' to create a savings account, press 'd' to create a current account, press 'e' for withdrawal, Press 'f' for deposit, press 'g' for transfer, press 'h' to go back to main menu");
                        choice = Console.ReadLine();

                        if (choice == "c") 
                        {
                            var savings = new Account(person.Id, person.Name, "savings");
                            person.Accounts.Add(savings);
                            bank.allAccounts.Add(savings);
                            Console.WriteLine($"Cusomer {person.Name} has created a savings account with account number {savings.Id}");
                        }

                        if (choice == "d")
                        {
                            var current = new Account(person.Id, person.Name, "current");
                            person.Accounts.Add(current);
                            bank.allAccounts.Add(current);
                            Console.WriteLine($"Cusomer {person.Name} has created a current account with account number {current.Id}");
                        }

                        if (choice == "e")
                        {
                            
                            Console.WriteLine("withdraw");
                        }

                        if (choice == "f")
                        {
                            Console.WriteLine("deposit");
                        }

                        if (choice == "g")
                        {
                            Console.WriteLine("transfer");
                        }

                    } while (choice != "h");


                }// If customer chooses to sign in
                else if (choice.Equals("b"))
                {

                }


            } while (choice.Equals("q" ) == false);
        }
    }
}
