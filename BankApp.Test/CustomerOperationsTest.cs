using BankApp.CustomerAccount;
using BankApp.CustomerAccount.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Test
{
    public class CustomerOperationsTest
    {
        //[Theory]
        //[InlineData(500)]
        //[InlineData(800)]
        //[InlineData(900)]
        //[InlineData(200)]
        //public void Withdrawal_SuccessfulOnValidAmount(decimal expected)
        //{
        //    //Arrange
        //    BaseAccount baseAcc = new BaseUserAccount("John", "Doe", "jdoe@gmail.com", 123456);

        //    //ACT
        //    baseAcc.MakeDeposit(1000, "Initial Deposit");
        //    baseAcc.MakeWithdrawal(500, "food bill");

        //    //ASSERT
        //    Assert.Equal(expected, baseAcc.Balance);
        //}

        //[Fact]
        //public void Withdrawal_UnSuccessfulOnInValidAmount()
        //{
        //    //Arrange
        //    BaseAccount baseAcc = new BaseAccount("John", "Doe", "jdoe@gmail.com", 123456);
        //    var expected = "No sufficient funds for this withdrawal";

        //    //ACT
        //    baseAcc.MakeDeposit(1000, "Initial Deposit");
        //    Action act = () => baseAcc.MakeWithdrawal(1200, "Electricity bill");
        //    var exception = Assert.Throws<InvalidOperationException>(act);

        //    //ASSERT
        //    Assert.Equal(expected, exception.Message);
        //}
    }
}
