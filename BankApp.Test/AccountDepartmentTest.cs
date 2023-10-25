using BankApp.AccountDepartment.Core;
using BankApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Test
{
    public class AccountDepartmentTest
    {

        [Fact]
        public void CreateUser_ShouldCreateUser()
        {
            //Arrange
            var dataSource = new Mock<IAccountOperations>();


            var newUserToCreate = new UserViewModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "jdoe@yh.com",
                Password = "password",
            };

            var newUser = new User(newUserToCreate.FirstName, newUserToCreate.LastName, 
                newUserToCreate.Email, newUserToCreate.Password);

            dataSource.Setup((m) => m.CreateUser(It.IsAny<UserViewModel>()))
                .Returns(newUser);

            var accDept = new AccountDept(dataSource.Object);

            //Act
            var actualUser = accDept.CreateUser(It.IsAny<UserViewModel>());

            //Assert
            Assert.Equal(newUser, actualUser);

        }

        [Fact]
        public void CreateUser_ShouldRegisterAUser()
        {
            //Arrange
            string firstName = "John";
            string lastName = "Doe";
            string email = "Jdoe@yahoo.com";
            string password = "password";
            string actual = "John";
            UserViewModel userVM = new UserViewModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            //Act
            AccountOperations accOperations = new AccountOperations();

            var userCreated = accOperations.CreateUser(userVM);

            string expected = userCreated.firstName; 

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateUser_ShouldFailToCreateWithWrongName()
        {
            //Arrange
            string firstName = "a1111111";
            string lastName = "Doe";
            string email = "Jdoe@yahoo.com";
            string password = "password";

            string expected = "Name not correct";

            //Act
            AccountOperations accOperations = new AccountOperations();

            UserViewModel userVM = new UserViewModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            //var acc = accOperations.CreateUser(userVM);

            Assert.Throws<ArgumentException>(() => accOperations.CreateUser(userVM));

            //Assert.Throws<Exception>("firs);

        }

        [Fact]
        public void CreateUser_ShouldReturnCorrectErrorMessage()
        {
            //Arrange
            string firstName = "a1111111";
            string lastName = "Doe";
            string email = "Jdoe@yahoo.com";
            string password = "password";

            string expected = "Name not correct";

            //Act
            AccountOperations accOperations = new AccountOperations();

            UserViewModel userVM = new UserViewModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            //var acc = accOperations.CreateUser(userVM);

            Action act = (() => accOperations.CreateUser(userVM));

            var exception = Assert.Throws<ArgumentException>(act);

            Assert.Equal(expected, exception.Message);
        }
    }
}
