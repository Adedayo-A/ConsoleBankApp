using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.CustomerAccount.Core
{
    public class SavingsCustomerOperations : ISavingsOperations
    {
        public Transaction Deposit(decimal amount, string note)
        {
            throw new NotImplementedException();
        }

        public Transaction Withdrawal(decimal amount, string note, decimal Balance)
        {
            throw new NotImplementedException();
        
        }
    }
}
