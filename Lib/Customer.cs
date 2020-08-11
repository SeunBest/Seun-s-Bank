using System;
using System.Collections.Generic;
using Seun_s_Bank.Lib;
using Seun_s_Bank.Data;

namespace Seun_s_Bank
{
    public class Customer
    {
        //properties
        #region Customer Properties
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime date { get; set; }
        public List<Account> Accounts
        {
            get
            {
                var acts = new List<Account>();
                foreach (var act in Bank.allAccounts)
                {
                    if (act.OwnerID == Id)
                    {
                        acts.Add(act);
                    }
                }
                return acts;
            }
        }
        #endregion

        public Customer(string name, string email, string password)
        {
            this.Id = CreateID();
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        public string CreateID()
        {
            int customers = Bank.allCustomers.Count + 1;
            foreach (var customer in Bank.allCustomers)
            {
                if (customers == Convert.ToInt32(customer.Id))
                    customers += 1;
            }
            return customers.ToString();
        }
    }
}
