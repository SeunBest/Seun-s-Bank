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

        public Customer(string name, int id, string email)
        {
            this.Name = name;
            this.Id = id;
            this.Email = email;
        }

        public List<Account> Accounts = new List<Account>();


        public void CreateCurrent(decimal initial, DateTime date)
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
