using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.CustomerAccount.Core
{
    public interface ICustomerOperations
    {
        Transaction Withdrawal(decimal amount, string note, decimal Balance);

        Transaction Deposit(decimal amount, string note);
    }
}
