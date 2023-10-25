using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.CustomerAccount.Core;

namespace BankApp.CustomerAccount
{
    public class SavingsAccount : BaseAccount
    {
        private readonly ISavingsOperations _savingsOperations;

        public SavingsAccount(string firstName, string lastName, string email, int accNumber, 
           ISavingsOperations savingsOperations) 
            : base(firstName, lastName, email, accNumber, savingsOperations)
        {
        }

        public override void MakeWithdrawal(decimal amount, string note)
        {
            _customerOperations.Withdrawal(amount, note, Balance);
        }
    }
}
