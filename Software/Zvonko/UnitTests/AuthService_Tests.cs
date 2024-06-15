using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class AuthService_Tests
    {
        [Fact]
        public void HashPassword_GivenPassword_ReturnsHashedPassword()
        {
            var authService = new AuthServices();
            var password = "password";

            var hashedPassword = authService.HashPassword(password);
            
            Assert.NotNull(hashedPassword);
            Assert.NotEqual(password, hashedPassword);
        }

        [Fact]
        public void HashPassword_GivenEmptyString_ReturnsEmpty()
        {
            var authService = new AuthServices();
            var password = "";

            var hashedPassword = authService.HashPassword(password);

            Assert.Empty(hashedPassword);
        }

        [Fact]
        public void HashPassword_GivenNull_ReturnsEmpty()
        {
            var authService = new AuthServices();

            var hashedPassword = authService.HashPassword(null);

            Assert.Empty(hashedPassword);
        }

        [Fact]
        public void VerifyPassword_GivenPasswordAndHashedPassword_ReturnsTrue()
        {
            var authService = new AuthServices();
            var password = "password";
            var hashedPassword = authService.HashPassword(password);

            var result = authService.VerifyPassword(password, hashedPassword);

            Assert.True(result);
        }

        [Fact]
        public void VerfiyPassword_GivenEmptyPasswordAndValidHashedPassword_ReturnsFalse()
        {
            var authService = new AuthServices();
            var password = "password";
            var hashedPassword = authService.HashPassword(password);

            var result = authService.VerifyPassword("", hashedPassword);

            Assert.False(result);
        }

        [Fact]
        public void VerfiyPassword_GivenIncorrectPassword_ReturnsFalse()
        {
            var authService = new AuthServices();
            var password = "password";
            var hashedPassword = authService.HashPassword(password);

            var result = authService.VerifyPassword("incorrectPass", hashedPassword);

            Assert.False(result);
        }

        [Fact]
        public void ValidateInput_GivenUsernameAndPassword_ReturnsTrue()
        {
            var authService = new AuthServices();
            var username = "username";
            var password = "password";

            var result = authService.ValidateInput(username, password);

            Assert.True(result);
        }

        [Fact]
        public void ValidateInput_GivenEmptyUsernameAndCorrectPassword_ReturnsFalse()
        {
            var authService = new AuthServices();
            var username = "";
            var password = "password";

            var result = authService.ValidateInput(username, password);

            Assert.False(result);
        }

        [Fact]
        public void ValidateInput_GivenUsernameAndEmptyPassword_ReturnsFalse()
        {
            var authService = new AuthServices();
            var username = "username";
            var password = "";

            var result = authService.ValidateInput(username, password);

            Assert.False(result);
        }

        [Fact]
        public void ValidateInput_GivenEmptyUsernameAndEmptyPassword_ReturnsFalse()
        {
            var authService = new AuthServices();
            var username = "";
            var password = "";

            var result = authService.ValidateInput(username, password);

            Assert.False(result);
        }

        [Fact]
        public void ValidateRegistrationInput_GivenUsernamePasswordAndSchoolName_ReturnsTrue()
        {
            var authService = new AuthServices();
            var username = "username";
            var password = "password";
            var schoolName = "schoolName";

            var result = authService.ValidateRegistrationInput(username, password, schoolName);

            Assert.True(result);
        }

        [Fact]
        public void ValidateRegistrationInput_GivenEmptyUsernamePasswordAndSchoolName_ReturnsFalse()
        {
            var authService = new AuthServices();
            var username = "";
            var password = "";
            var schoolName = "";

            var result = authService.ValidateRegistrationInput(username, password, schoolName);

            Assert.False(result);
        }

        [Fact]
        public void ValidateRegistrationInput_GivenEmptyUsernameAndEmptyPasswordAndSchoolName_ReturnsFalse()
        {
            var authService = new AuthServices();
            var username = "";
            var password = "";
            var schoolName = "schoolName";

            var result = authService.ValidateRegistrationInput(username, password, schoolName);

            Assert.False(result);
        }

        [Fact]
        public void ValidateRegistrationInput_GivenEmptyUsernameAndPasswordAndEmptySchoolName_ReturnsFalse()
        {
            var authService = new AuthServices();
            var username = "";
            var password = "password";
            var schoolName = "";

            var result = authService.ValidateRegistrationInput(username, password, schoolName);

            Assert.False(result);
        }

        [Fact]
        public void ValidateRegistrationInput_GivenUsernameAndPasswordAndEmptySchoolName_ReturnsFalse()
        {
            var authService = new AuthServices();
            var username = "username";
            var password = "password";
            var schoolName = "";

            var result = authService.ValidateRegistrationInput(username, password, schoolName);

            Assert.False(result);
        }
    }
}
