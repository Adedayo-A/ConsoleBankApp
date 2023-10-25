using BankApp.CustomerAccount;
using BankApp.CustomerAccount.Core;
using BankApp.Enums;
using BankApp.Helpers;
using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AccountDepartment.Core
{
    public class AccountOperations : IAccountOperations
    {
        public BaseAccount CreateBaseAccount(CreateBaseAccountVM createBaseAccountVM, 
            long accNumber, ICustomerOperations customerOperations)
        {
            BaseAccount newAccount = new BaseAccount(createBaseAccountVM.FirstName,
                createBaseAccountVM.LastName, createBaseAccountVM.Email, 
                accNumber, customerOperations);

            return newAccount;
        }

        public BaseAccount CreateCurrentAccount()
        {
            throw new NotImplementedException();
        }

        public BaseAccount CreateSavingsAccount()
        {
            throw new NotImplementedException();
        }

        public User CreateUser(UserViewModel userVM)
        {
            //CHECK FIRSTNAME
            if (HelperMethods.ValidName(userVM.FirstName) == false)
            {
                throw new ArgumentException("Name not correct");
            }

            //VALIDATE LASTNAME
            if (HelperMethods.ValidName(userVM.LastName) == false)
            {
                throw new Exception("Last Name not correct");
            }

            //VALIDATE EMAIL
            if (HelperMethods.ValidateEmail(userVM.Email) == false)
            {
                throw new Exception("Email Not correct");
            }

            //VALIDATE PASSWORD
            if (HelperMethods.ValidatePassword(userVM.Password) == false)
            {
                throw new Exception("Invalid Password");
            }

            User newUser = new User(userVM.FirstName, userVM.LastName, userVM.Email, userVM.Password);

            return newUser;

        }

        public User? GetUser(string fileName, string email)
        {
            var users = GetUsers(fileName);
            if(users == null)
            {
                return null;
            }

            User? userFound = users.Find(u => u.email == email);

            return userFound;
        }

        public User? GetUser(List<User> users, string email)
        {
            if (users == null)
            {
                return null;
            }

            User? userFound = users.Find(u => u.email == email);

            return userFound;
        }

        public List<User> GetUsers(string filename)
        {
            var users = JsonFileUtilsNewton.ReadFiles<User>(filename);

            return users;
        }

        public BaseAccount? GetAccount(List<BaseAccount> accounts, int accountId)
        {
            if (accounts == null)
            {
                return null;
            }

            BaseAccount? account = accounts.Find(acc => acc.AccountId == accountId);

            return account;
        }

        public BaseAccount? GetAccount(string filename, int id)
        {
            var accounts = GetAccounts(filename);

            if (accounts == null)
            {
                return null;
            }

            BaseAccount? account = accounts.Find(acc => acc.AccountId == id);

            return account;
        }

        public List<BaseAccount> GetAccounts(string filename)
        {
            var accounts = JsonFileUtilsNewton.ReadFiles<BaseAccount>(filename);

            return accounts;
        }

        public void AddUser(List<User> users, string filename)
        {
            JsonFileUtilsNewton.SimpleWrite(users, filename);
        }

        public void AddAccount(List<BaseAccount> accounts, string filename)
        {
            JsonFileUtilsNewton.SimpleWrite(accounts, filename);
        }
    }
}
