using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BankApp.CustomerAccount.Core;
using BankApp.Models;
using Newtonsoft.Json;

namespace BankApp.CustomerAccount
{
    public class BaseAccount
    {
        //Auto Implemented Property

        public int AccountId { get; set; }
        public long AccountNumber { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        [JsonIgnore]
        public ICustomerOperations _customerOperations { get;}

        //public AccountType AccountType { get; }

        private List<Transaction> _allTransactions = new List<Transaction>(); 


        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        //CONSTRUCTOR
        public BaseAccount(string firstName, string lastName, string email,
            long accNumber, ICustomerOperations customerOperations)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            AccountNumber = accNumber;
            this._customerOperations = customerOperations;
            //AccountType = accountType;
            //MakeDeposit(0, "Initial balance");
        }

        public virtual void MakeDeposit(decimal amount, string note)
        {
            var depositTransaction = _customerOperations.Deposit(amount, note);

            _allTransactions.Add(depositTransaction);
        }

        public virtual void MakeWithdrawal(decimal amount, string note)
        {
            var withdrawalTransaction = _customerOperations.Withdrawal(amount, note, Balance);
            _allTransactions.Add(withdrawalTransaction);
        }

    }
}
