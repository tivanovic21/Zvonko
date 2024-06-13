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
        public void HashPassword_GivenValidPassword_ReturnsHashedPassword()
        {
            // Arrange
            var authServices = new AuthServices();
            var password = "testPassword";

            // Act
            var result = authServices.HashPassword(password);

            // Assert
            Assert.NotEmpty(result);
            Assert.NotEqual(password, result);
        }

        [Fact]
        public void VerifyPassword_GivenCorrectPassword_ReturnsTrue()
        {
            // Arrange
            var authServices = new AuthServices();
            var password = "testPassword";
            var hashedPassword = authServices.HashPassword(password);

            // Act
            var result = authServices.VerifyPassword(password, hashedPassword);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifyPassword_GivenIncorrectPassword_ReturnsFalse()
        {
            // Arrange
            var authServices = new AuthServices();
            var password = "testPassword";
            var hashedPassword = authServices.HashPassword(password);

            // Act
            var result = authServices.VerifyPassword("incorrectPassword", hashedPassword);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateInput_GivenValidInput_ReturnsTrue()
        {
            // Arrange
            var authServices = new AuthServices();
            var username = "testUser";
            var password = "testPassword";

            // Act
            var result = authServices.ValidateInput(username, password);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidateInput_GivenInvalidInput_ReturnsFalse()
        {
            // Arrange
            var authServices = new AuthServices();
            string username = "";
            string password = "test";

            // Act
            var result = authServices.ValidateInput(username, password);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateRegistrationInput_GivenValidInput_ReturnsTrue()
        {
            // Arrange
            var authServices = new AuthServices();
            var username = "testUser";
            var password = "testPassword";
            var schoolName = "testSchool";

            // Act
            var result = authServices.ValidateRegistrationInput(username, password, schoolName);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidateRegistrationInput_GivenEmptyUsername_ReturnsFalse()
        {
            // Arrange
            var authServices = new AuthServices();
            var username = "";
            var password = "testPassword";
            var schoolName = "testSchool";

            // Act
            var result = authServices.ValidateRegistrationInput(username, password, schoolName);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateRegistrationInput_GivenEmptyPassword_ReturnsFalse()
        {
            // Arrange
            var authServices = new AuthServices();
            var username = "testUsername";
            var password = "";
            var schoolName = "testSchool";

            // Act
            var result = authServices.ValidateRegistrationInput(username, password, schoolName);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateRegistrationInput_GivenEmptySchoolName_ReturnsFalse()
        {
            // Arrange
            var authServices = new AuthServices();
            var username = "testUsername";
            var password = "testPassword";
            var schoolName = "";

            // Act
            var result = authServices.ValidateRegistrationInput(username, password, schoolName);

            // Assert
            Assert.False(result);
        }
    }
}
