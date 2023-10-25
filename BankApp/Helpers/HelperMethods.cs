using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Helpers
{
    internal static class HelperMethods
    {
        public static bool ValidateEmail(string email)
        {

            bool isValid = 
                !string.IsNullOrEmpty(email)
                && email.Contains('@') && email.Contains('.')
                && email.IndexOf('@') < email.LastIndexOf('.');

            return isValid;
        }

        public static bool ValidatePassword(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 6;
        }

        public static bool ValidName(string name)
        {
            var isValid = !string.IsNullOrWhiteSpace(name) && name.Any() && !char.IsLower(name[0]);

            return isValid;
        }

        internal static void ValidateData(string? firstname, string? lastname, string? email, string? password)
        {
            throw new NotImplementedException();
        }

        internal static bool ValidateYesOrNo(string input)
        {
            return !string.IsNullOrEmpty(input) && int.Parse(input) >= 1 && int.Parse(input) <= 2;
        }

        internal static bool ValidateBankOptions(string input)
        {
            return !string.IsNullOrEmpty(input) && int.Parse(input) >= 1 && int.Parse(input) <= 7;
        }
    }
}
