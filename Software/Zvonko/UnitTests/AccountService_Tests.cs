using BusinessLogicLayer;
using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class AccountService_Tests
    {
        [Fact]
        public void GetAccount_GivenCorrectUsername_ReturnsAccount()
        {
            // Arrange
            var accountService = new AccountService();

            // Act
            var result = accountService.GetAccount("dev");

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAccount_GivenIncorrectUsername_RetrunsNull()
        {
            // Arrange
            var accountService = new AccountService();

            // Act
            var result = accountService.GetAccount("incorrectUsername");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetAccount_GivenEmptyString_ReturnsNull()
        {
            // Arrange
            var accountService = new AccountService();

            // Act
            var result = accountService.GetAccount("");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddAccount_GivenValidAccount_ReturnsTrue()
        {
            // Arrange
            var accountService = new AccountService();
            var newAccount = new Account
            {
                username = "newTestUser",
                password = "newTestUser",
                schoolName = "new test school",
            };

            // Act 
            var result = accountService.AddAccount(newAccount);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddAccount_GivenNullAccount_ReturnsFalse()
        {
            // Arrange
            var accountService = new AccountService();

            // Act
            var result = accountService.AddAccount(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void AddAccount_GivenInvalidAccount_ReturnsFalse()
        {
            // Arrange
            var accountService = new AccountService();
            var newAccount = new Account
            {
                username = "newTestUserNoSchool",
                password = "newTestUserNoSchool",
            };

            // Act 
            var result = accountService.AddAccount(newAccount);

            // Assert
            Assert.False(result);
        }
    }
}
