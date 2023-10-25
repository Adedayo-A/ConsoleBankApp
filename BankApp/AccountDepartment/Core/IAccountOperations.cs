using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.CustomerAccount;
using BankApp.CustomerAccount.Core;
using BankApp.Models;

namespace BankApp.AccountDepartment.Core
{
    public interface IAccountOperations
    {
        User CreateUser(UserViewModel userVM);

        BaseAccount CreateSavingsAccount();

        BaseAccount CreateCurrentAccount();

        BaseAccount CreateBaseAccount(CreateBaseAccountVM createBaseAccountVM, 
            long accNumber, ICustomerOperations customerOperations);

        List<User> GetUsers(string fileName);

        User? GetUser(string filename, string email);

        User? GetUser(List<User> users, string email);

        void AddUser(List<User> users,string filename);
        void AddAccount(List<BaseAccount> accounts,string filename);

        BaseAccount? GetAccount(string filename, int accountId);

        BaseAccount? GetAccount(List<BaseAccount> accounts, int accountId);

        List<BaseAccount> GetAccounts(string filename);

    }
}
