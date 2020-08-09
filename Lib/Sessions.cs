using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Seun_s_Bank.Data;
using Seun_s_Bank.Help;
using Seun_s_Bank.Lib;

namespace Seun_s_Bank.Lib
{
    public static class Sessions
    {
        //tracks if a login session is in progress
        public static bool status { get; set; }

        public static Account Register (string name, string email, string pass, typeOfAcc type, decimal bal)
        {
            //initialize customer and account to null
            Customer cus = null;
            Account acc = null;

            //create Customer
            cus = new Customer(name, email, pass);

            //create Account
            acc = new Account(cus.Id, type, bal);

            //update Customer and account lists;
            Bank.allCustomers.Add(cus);
            Bank.allAccounts.Add(acc);

            //create transaction
            var tr = new Transaction(acc.number, bal, "Opening balance", type.ToString(), DateTime.Now);

            //update transaction list;
            Bank.allTransactions.Add(tr);

            //Begin session
            new utility().createSession(cus.Id, cus.Name, cus.Email, acc.number);
            status = true;

            return acc;
        }

        public static Account Login (string email, string pass)
        {
            string Id = null;
            string Email = null;
            string Name = null;
            string Password = null;
            string AccNum = null;
            Account acc = null;

            //get records
            for (int i = 0; i < Bank.allCustomers.Count; i++)
            {
                if (Bank.allCustomers[i].Email == email)
                {               
                    Id = Bank.allCustomers[i].Id;
                    Email = Bank.allCustomers[i].Email;
                    Name = Bank.allCustomers[i].Name;
                    Password = Bank.allCustomers[i].Password;
                    break;
                }
            }

            // return null if email not found
            if (Email == null)
                return null;
            // return null if password does not match
            if (Password != pass)
                return null;
            

            // load up the customer account
            for (int i = 0; i < Bank.allAccounts.Count; i++)
            {
                if (Bank.allAccounts[i].OwnerID == Id)
                {
                    acc = new Account
                    {
                        AccType = Bank.allAccounts[i].AccType,
                        OwnerID = Bank.allAccounts[i].OwnerID
                    };
                    AccNum = Bank.allAccounts[i].number;
                }
            }

            // create the session
            new utility().createSession(Id, Name, Email, AccNum);
            status = true;

            return acc;

        }

        // Create the Logout method
        public static void Logout()
        {
            // clear out the user details from the seeion
            Log.Id = null;
            Log.Name = null;
            Log.Email = null;
            Log.AccNo = null;
            status = false;
        }
    }
}
