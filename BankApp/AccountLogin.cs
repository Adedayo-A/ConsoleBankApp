using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models;

namespace BankApp
{
    public class AccountLogin
    {
        public static User Login(string email, string password, FactoryClass fClass)
        {
            var user = new User();

            AccountDept accDept = new AccountDept(fClass.accountOperations);

            var users = accDept.OurUsers;

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].password == password
                    && users[i].email == email)
                {
                    user = users[i];
                    break;
                }
            }

            return user;
        }
    }
}
