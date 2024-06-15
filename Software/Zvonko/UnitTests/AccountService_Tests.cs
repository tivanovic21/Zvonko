using BusinessLogicLayer;
using DatabaseLayer.TestRepositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using Xunit;
using DatabaseLayer;

namespace UnitTests
{
    public class AccountService_Tests
    {
        private IAccountRepository _fakeRepo;
        private AccountService _accountService;

        public AccountService_Tests()
        {
            _fakeRepo = A.Fake<IAccountRepository>();
            _accountService = new AccountService(_fakeRepo);
        }

        [Fact]
        public void AddAccount_NullAccount_ReturnsFalse()
        {
            var result = _accountService.AddAccount(null);
            Assert.False(result);
        }

        [Fact]
        public void AddAccount_InvalidAccount_ReturnsFalse()
        {
            var account = new Account { username = null, password = "pass", schoolName = "school" };
            var result = _accountService.AddAccount(account);
            Assert.False(result);
        }

        [Fact]
        public void AddAccount_ValidAccount_ReturnsTrue()
        {
            var account = new Account { username = "user", password = "pass", schoolName = "school" };
            A.CallTo(() => _fakeRepo.Add(account, true)).Returns(1);

            var result = _accountService.AddAccount(account);

            Assert.True(result);
        }

        [Fact]
        public void GetAccount_ValidAccount_ReturnsAccoutn()
        {
            var account = new Account { username = "user", password = "pass", schoolName = "school" };
            A.CallTo(() => _fakeRepo.Get("user")).Returns(account);

            var result = _accountService.GetAccount("user");

            Assert.Equal(account, result);
        }

        [Fact]
        public void GetAccount_InvalidUsername_ReturnsNull()
        {
            A.CallTo(() => _fakeRepo.Get("userDoesNotExist")).Returns(null);

            var result = _accountService.GetAccount("userDoesNotExist");

            Assert.Null(result);
        }
    }
}
