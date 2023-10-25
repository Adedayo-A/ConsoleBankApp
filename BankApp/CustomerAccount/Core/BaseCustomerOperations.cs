using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.CustomerAccount.Core

    //SEALED AND NEW
{
    public class BaseCustomerOperations : ICustomerOperations
    {
        public Transaction Deposit(decimal amount, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var depositTransaction = new Transaction(amount, DateTime.Now, note);

            return depositTransaction;
        }

        public Transaction Withdrawal(decimal amount, string note, decimal Balance)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawalTransaction = new Transaction(-amount, DateTime.Now, note);

            return withdrawalTransaction;
        }
    }
}
