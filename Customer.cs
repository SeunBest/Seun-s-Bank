using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Seun_s_Bank
{
    public class Customer
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Customer(string name, string email, string password)
        {
            Random nums = new Random();

            this.Id = nums.Next(101, 1000);
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        public List<Account> Accounts = new List<Account>();


        public void CreateAccount(decimal initial, DateTime date)
        {
            
        }

        public void Login(string email)
        {

        }

        public void GetBalance()
        {
            
            Console.WriteLine();
        }

        public void getStatement()
        {
        
        }
    }
}
