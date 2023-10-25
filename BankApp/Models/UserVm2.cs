using BankApp.CustomerAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class UserVm2 : UserViewModel
    {
        public List<BaseUserAccount> Accounts { get; set; }
    }
}
