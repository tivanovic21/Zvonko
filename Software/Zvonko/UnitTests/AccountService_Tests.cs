using BusinessLogicLayer;
using DatabaseLayer;
using DatabaseLayer.TestRepositories;
using FakeItEasy;
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
        public void Get_GivenValidAccount_ReturnsNotNull()
        {
            // Arrange
            var repo = A.Fake<IAccountRepository>();
            var account = new Account
            {
                id = 1,
                username = "fakeAcc",
                password = "fakePass",
                schoolName = "fakeSchool"
            };
            A.CallTo(() => repo.Get("fakeAcc")).Returns(account);
            var accountService = new AccountService(repo);

            // Act
            var getAccount = accountService.GetAccount("fakeAcc");

            // Assert
            Assert.NotNull(getAccount);
            Assert.Equal("fakeAcc", getAccount.username);
        }

        [Fact]
        public void Get_GivenNullAccount_ReturnsNull()
        {
            // Arrange
            var repo = A.Fake<IAccountRepository>();
            var account = null as Account;
            A.CallTo(() => repo.Get("fakeAcc")).Returns(account);
            var accountService = new AccountService(repo);

            // Act
            var getAccount = accountService.GetAccount("fakeAcc");

            // Assert
            Assert.Null(getAccount);
        }
    }
}
