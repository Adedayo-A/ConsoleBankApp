using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.AccountDepartment.Core;
using BankApp.CustomerAccount;
using BankApp.Helpers;
using BankApp.Models;
using static System.Console;

namespace BankApp.Pages
{
    internal static class WelcomePage
    {
        static string FirstName;
        static string LastName;
        static string Email;
        static string Password;


        public static void Menu(FactoryClass fClass)
        {
            WriteLine("***************************");

            WriteLine("1: Login\n2: Sign Up\nEnter any other key to exit");

            WriteLine("\n***************************\n");

            Write("Select option: ");

            string option = ReadLine();

            if (option == "1")
            {
                GetLoginUserDetails();

                //LOGIN USER
                var user = AccountLogin.Login(Email, Password, fClass);

                //CHECK IF USER HAS AN ACCOUNT
                if (user.AccountIds.Count > 0)
                {
                    AccountDept accDept = new AccountDept(fClass.accountOperations);
                    var userAccounts = accDept.GetUserAccounts(user.AccountIds);

                    //User has an account.
                    MainMenu.Menu(user, fClass, userAccounts);
                }
                else if (user.email == null)
                {
                    Clear();
                    WriteLine("User not found. Enter a valid Email and Password");
                    Menu(fClass);
                }
                else
                {
                    //We have a user and for God knows what, the user doesn't have an account.
                    Clear();
                    WriteLine("This user does not have an account. Kindly meet Customer Service");
                    Menu(fClass);
                }
            }
            else if (option == "2")
            {
                GetRegUserDetails();

                AccountDept accDept = new AccountDept(fClass.accountOperations);

                UserViewModel uVModel = new UserViewModel
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Password = Password
                };

                var newUser = accDept.CreateUser(uVModel);

                CreateBaseAccountVM createBaseAccountVM = new CreateBaseAccountVM
                {
                    FirstName = newUser.firstName,
                    LastName = newUser.lastName,
                    Email = newUser.email,
                };

                var listUsers = accDept.OurUsers;
                var listAcc = accDept.OurAccounts;

                //Check if File is Empty
                if (listUsers == null)
                {
                    listUsers = new List<User> { newUser };
                    //accDept.PopulateUsers(newUser);
                }
                else
                {
                    bool exists = accDept.CheckUser(newUser.email);

                    if (exists)
                    {
                        Clear();
                        WriteLine("User already exist");

                        Menu(fClass);
                    }

                    listUsers.Add(newUser);

                    //accDept.PopulateUsers(newUser);
                }

                //Account

                long accountNumber = accDept.GenerateAccountNumber();

                var newAccount = accDept.CreateAccount(createBaseAccountVM, 
                    fClass.customerOperations, accountNumber);

                if (listAcc == null)
                {
                    listAcc = new List<BaseAccount> { newAccount };
                }
                else
                {
                    listAcc.Add(newAccount);
                }

                accDept.SaveAccount(listAcc);

                newUser.AccountIds.Add(newAccount.AccountId);

                //SAVE USER
                accDept.SaveUser(listUsers);

                MainMenu.Menu(newUser, fClass, listAcc);
            }
            else
            {
                WriteLine("Program exited.");
                Environment.Exit(0);
            }
        }
        private static void GetLoginUserDetails()
        {
            WriteLine("Enter email");

            Email = ReadLine();

            WriteLine("Enter password");

            Password = ReadLine();

            while (HelperMethods.ValidateEmail(Email) == false)
            {
                WriteLine("Please enter a valid email address");

                Email = ReadLine();
            }
        }
        private static void GetRegUserDetails()
        {
            WriteLine("Enter your firstname");

            FirstName = ReadLine();

            //CHECK FIRSTNAME
            while (HelperMethods.ValidName(FirstName) == false)
            {
                WriteLine("Invalid input! Enter a valid name: ");

                FirstName = ReadLine();
            }

            WriteLine("Enter your lastname");
            LastName = ReadLine();

            //VALIDATE LASTNAME
            while (HelperMethods.ValidName(LastName) == false)
            {
                WriteLine("Invalid input! Enter a valid name: ");

                LastName = ReadLine();
            }

            WriteLine("Enter your Email");

            Email = ReadLine();

            //VALIDATE EMAIL
            while (HelperMethods.ValidateEmail(Email) == false)
            {
                WriteLine("Invalid input!\nEnter a valid email: ");
                Email = ReadLine();
            }

            WriteLine("Enter your Password");
            Password = ReadLine();

            //VALIDATE PASSWORD
            while (HelperMethods.ValidatePassword(Password) == false)
            {
                WriteLine("Invalid Password!\nEnter a 6 digit password: ");
                Password = ReadLine();
            }
        }
    }
}
