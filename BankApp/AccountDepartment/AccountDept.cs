using BankApp.AccountDepartment.Core;
using BankApp.CustomerAccount;
using BankApp.CustomerAccount.Core;
using BankApp.Enums;
using BankApp.Helpers;
using BankApp.Models;
using BankApp.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankApp
{
    public class AccountDept
    {
        public List<User> OurUsers { get; private set; }
        
        public List<BaseAccount> OurAccounts = new List<BaseAccount>();

        private const string OurUsersFileName = @"C:\BankApp\OurUsers.json";
        private const string AccountsDB = @"C:\BankApp\Accounts.json";

        public readonly IAccountOperations _accountOperations;

        private string AccountChoice;

        public AccountDept(IAccountOperations operations)
        {
            _accountOperations = operations;
            GetUsers();
            GetAccounts();
        }

        public User CreateUser(UserViewModel userVM)
        { 
            //CREATE CUSTOMER OBJECT
            var newUser = _accountOperations.CreateUser(userVM);
            return newUser;
        }

        public bool CheckUser(string email)
        {
            bool exist = true;

            if (GetUserV2(email) == null)
            {
                exist = false;

                return exist;
            }

            return exist;
        }

        //public void PopulateUsers(User newUser)
        //{
        //    OurUsers.Add(newUser);
        //}

        public void SaveUser(List<User> usersList) 
        {
            try
            {
                _accountOperations.AddUser(usersList, OurUsersFileName);
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"An error occured {ex.Message}");
                return;
            }
        }

        public BaseAccount CreateAccount(CreateBaseAccountVM createModel, 
            ICustomerOperations customerOperations, long accNumber)
        {
            var newAccount = _accountOperations.CreateBaseAccount(createModel, accNumber, customerOperations);

            return newAccount;
        }

        public void SaveAccount(List<BaseAccount> accounts)
        {
            try
            {
                _accountOperations.AddAccount(accounts, AccountsDB);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured {ex.Message}");

                return;
            }
        }

        public void ChooseAccountType()
        {
            Console.WriteLine("Chooose your preferred account type");

            Console.WriteLine("1: Savings Account\n2: Current Account");

            AccountChoice = Console.ReadLine();
            bool isValid = HelperMethods.ValidateYesOrNo(AccountChoice);
            while (isValid == false)
            {
                Console.WriteLine("Input correct option");
                AccountChoice = Console.ReadLine();
            }
        }

        public User? GetUser(string email)
        {
            User user;
            user = _accountOperations.GetUser(OurUsersFileName,email);

            return user;
        }

        public User? GetUserV2(string email)
        {
            User user;
            user = _accountOperations.GetUser(OurUsers, email);

            return user;
        }

        public void GetUsers()
        {
            try
            {
               OurUsers = _accountOperations.GetUsers(OurUsersFileName);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occured {ex.Message}");
            }
        }

        public void GetAccounts()
        {
            try
            {
                OurAccounts = _accountOperations.GetAccounts(AccountsDB);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"An error occured {ex.Message}");
            }
        }

        public BaseAccount? GetAccount(int accountId)
        {
            BaseAccount acc = null;
            try
            {
                acc = _accountOperations.GetAccount(AccountsDB, accountId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured {ex.Message}");
            }

            return acc;
        }

        public BaseAccount? GetAccountV2(int accountId)
        {
            BaseAccount acc = null;
            try
            {
                acc = _accountOperations.GetAccount(OurAccounts, accountId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured {ex.Message}");
            }

            return acc;
        }

        public List<BaseAccount> GetUserAccounts(List<int> accountIds)
        {
            List<BaseAccount> accounts = new List<BaseAccount>();

            foreach (var accountId in accountIds)
            {
                var userAcc = accounts.Find(acc => acc.AccountId == accountId);

                accounts.Add(userAcc);
            }

            return accounts;
        }

        public int GetLastAccountId ()
        {
            int lastElementIndex = OurAccounts.Count - 1;
            int id = OurAccounts[lastElementIndex].AccountId;

            return id;

        }
        public long GenerateAccountNumber()
        {
            long newAccNum;

            if (OurAccounts.Count == 0)
            {
                newAccNum = 0000001;
                
                return newAccNum;
            }

            int lastElementIndex = OurAccounts.Count - 1;
            newAccNum = OurAccounts[lastElementIndex].AccountNumber + 1;

            return newAccNum;
        }

    }
}
