using System;
using System.Collections.Generic;
using System.Text;
using Seun_s_Bank.Lib;
using Seun_s_Bank.Data;

namespace Seun_s_Bank.Help
{
    public class utility
    {
        public void createSession(string Id, string Name, string Email, string accNum)
        {
            // create login session
            Log.Id = Id;
            Log.Name = Name;
            Log.Email = Email;
            Log.AccNo = accNum;
        }
    }
}
