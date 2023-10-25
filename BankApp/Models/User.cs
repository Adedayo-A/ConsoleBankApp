using System.Security.Principal;
using BankApp.CustomerAccount;

namespace BankApp.Models
{
    public class User
    {
        //Difference between Readonly/{get;} and Private Set
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public List<int> AccountIds = new List<int>();

        public User(string firstName, string lastName, string email, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
        }

        public User()
        {

        }

    }
}