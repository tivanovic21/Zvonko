using BusinessLogicLayer;
using DatabaseLayer;
using DatabaseLayer.TestRepositories;
using FakeItEasy;
using Xunit;

namespace UnitTests {
    public class AccountService_Tests {
        private readonly IAccountRepository _fakeRepo;
        private readonly AccountService _accountService;

        public AccountService_Tests() {
            _fakeRepo = A.Fake<IAccountRepository>();
            _accountService = new AccountService(_fakeRepo);
        }

        [Fact]
        public void AddAccount_NullAccount_ReturnsFalse() {
            var result = _accountService.AddAccount(null);
            Assert.False(result);
        }

        [Fact]
        public void AddAccount_InvalidAccount_ReturnsFalse() {
            var account = new Account { username = null, password = "pass", schoolName = "school" };
            var result = _accountService.AddAccount(account);
            Assert.False(result);
        }

        [Fact]
        public void AddAccount_ValidAccount_ReturnsTrue() {
            var account = new Account { username = "user", password = "pass", schoolName = "school" };
            A.CallTo(() => _fakeRepo.Add(account, true)).Returns(1);

            var result = _accountService.AddAccount(account);

            Assert.True(result);
        }

        [Fact]
        public void GetAccount_ValidAccount_ReturnsAccount() {
            var account = new Account { username = "user", password = "pass", schoolName = "school" };
            A.CallTo(() => _fakeRepo.Get("user")).Returns(account);

            var result = _accountService.GetAccount("user");

            Assert.Equal(account, result);
        }

        [Fact]
        public void GetAccount_InvalidUsername_ReturnsNull() {
            A.CallTo(() => _fakeRepo.Get("userDoesNotExist")).Returns(null);

            var result = _accountService.GetAccount("userDoesNotExist");

            Assert.Null(result);
        }

        
        [Fact]
        public void UpdateAccount_ValidAccount_ReturnsAffectedRows() {
            var account = new Account { username = "userUpd", password = "userUpd", schoolName = "schoolUpd", macAddress = "00:00:00:00" };
            A.CallTo(() => _fakeRepo.Update(account, true)).Returns(1);

            var result = _accountService.UpdateAccount(account);

            Assert.Equal(1, result);
        }

        [Fact]
        public void UpdateAccount_InvalidAccount_ReturnsZero() {
            var account = new Account { username = "fakeAcc" };
            A.CallTo(() => _fakeRepo.Update(account, true)).Returns(0);

            var result = _accountService.UpdateAccount(account);

            Assert.Equal(0, result);
        }

        [Fact]
        public void UpdateAccount_NullAccount_ReturnsZero() {
            var account = null as Account;
            A.CallTo(() => _fakeRepo.Update(account, true)).Returns(0);

            var result = _accountService.UpdateAccount(account);

            Assert.Equal(0, result);
        }
        
    }
}
