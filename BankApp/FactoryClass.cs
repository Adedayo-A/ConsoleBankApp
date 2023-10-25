using BankApp.AccountDepartment.Core;
using BankApp.CustomerAccount;
using BankApp.CustomerAccount.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class FactoryClass
    {
        public IAccountOperations accountOperations = new AccountOperations();

        public ICustomerOperations customerOperations = new BaseCustomerOperations();

    }
}
