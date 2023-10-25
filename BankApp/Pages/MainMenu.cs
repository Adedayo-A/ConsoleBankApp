using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BankApp.CustomerAccount;
using BankApp.Helpers;
using BankApp.Models;
using static System.Console;

namespace BankApp.Pages
{
    internal class MainMenu
    {
        public static void Menu(User customer, FactoryClass fClass, List<BaseAccount> userAccounts)
        {
            Clear();
            WriteLine("********************************************************************************************");
            WriteLine($"Welcome {customer.firstName}");

            WriteLine("Choose an operation:");
            WriteLine("1: Deposit Money\n2: Withdraw Money\n3: Check GetBalance\n4: Logout");

            string option = ReadLine();

            bool validateOption = HelperMethods.ValidateBankOptions(option);

            while (validateOption ==  false)
            {
                WriteLine("Incorrect option. Input correct option");
                option = ReadLine();
            }

            //NEED TO GET THE USER ACCOUNT

            AccountDept accDept = new AccountDept(fClass.accountOperations);

            BaseAccount userAcc = userAccounts.FirstOrDefault();

            //foreach (var accountId in accountIds)
            //{
            //    var accNum = accounts.Find(acc => acc.AccountId == accountId).AccountNumber;
            //    accNums.Add(accNum);

            //    userAcc = accounts.Find(acc => acc.AccountId == accountId);
            //}

            //BaseAccount theUserAccount = null;

            //foreach (var account in AccountDept.OurAccounts)
            //{
            //    if (customer.email == account.Email)
            //    {
            //        theUserAccount = account;
            //    }
            //}

            if (userAcc == null)
            {
                Clear();

                WriteLine("Account Not Found");

                // Flash prompt until user presses escape
                while (ConsoleStopwatch.FlashPrompt("Press escape to continue...",
                    TimeSpan.FromMilliseconds(500)) != ConsoleKey.Escape);

                // Code execution continues after they press escape...
                Clear();
                WelcomePage.Menu(fClass);
            }

            if (option == "1")
            {
                WriteLine("Enter the amount you wish to deposit");
                var Amount = ReadLine();
                decimal amount;

                while (!decimal.TryParse(Amount, out amount))
                {
                    WriteLine("Invalid input! Enter valid amount: ");
                    Amount = ReadLine();
                }

                WriteLine("Enter Deposit description");

                var notes = ReadLine();

                //Deposit
                userAcc.MakeDeposit(amount, notes);


                WriteLine("Will you like to perform any other transaction");

                WriteLine("1: Yes\n2: No");

                string answer = ReadLine();

                bool choice = HelperMethods.ValidateYesOrNo(answer);
                while (choice == false)
                {
                    WriteLine("Input correct option");
                    answer = ReadLine();
                }

                if (answer == "1")
                {
                    Menu(customer, fClass, userAccounts);
                }
                else if (answer == "2")
                {
                    Clear();
                    WelcomePage.Menu(fClass);
                }
            }
            else if (option == "2")
            {
                WriteLine("Enter the amount you wish to withdraw");
                var Amount = ReadLine();
                decimal amount;

                while (!decimal.TryParse(Amount, out amount))
                {
                    WriteLine("Invalid Input! Input correct value: ");
                    Amount = ReadLine();
                }

                WriteLine("Enter Withdrawal Description");

                var withdrawalNote = ReadLine();

                userAcc.MakeWithdrawal(amount, withdrawalNote);

                WriteLine("Will you like to perform any other transaction");

                WriteLine("1: Yes\n2: No");

                string answer = ReadLine();

                bool choice = HelperMethods.ValidateYesOrNo(answer);
                while (choice == false)
                {
                    WriteLine("Input correct option");
                    answer = ReadLine();
                }

                if (answer == "1")
                {
                    Menu(customer, fClass, userAccounts);
                }
                else if (answer == "2")
                {
                    Clear();
                    WelcomePage.Menu(fClass);
                }
            }

            else if (option == "3")
            {
                Clear();
                WriteLine($"Your account balance is {userAcc.Balance}");

                WriteLine("Will you like to perform any other transaction");

                WriteLine("1: Yes\n2: No");

                string answer = ReadLine();

                bool choice = HelperMethods.ValidateYesOrNo(answer);
                while (choice == false)
                {
                    WriteLine("Input correct option");
                    answer = ReadLine();
                }

                if (answer == "1")
                {
                    Menu(customer, fClass, userAccounts);
                }
                else if (answer == "2")
                {
                    Clear();
                    WelcomePage.Menu(fClass);
                }
            }
            else if (option == "4")
            {
                Clear();
                WelcomePage.Menu(fClass);
            }
        }
    }
}
