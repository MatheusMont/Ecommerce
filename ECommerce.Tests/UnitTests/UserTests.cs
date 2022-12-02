using System;
using System.Linq;
using Ecommerce.DOMAIN.Validations;
using Ecommerce.DOMAIN.Models;
using Xunit;
using Ecommerce.DOMAIN.Services;

namespace ECommerce.Tests.UnitTests
{
    public class UserTests
    {
        /*
        private readonly UserValidator _userValidator;
        public UserTests(UserValidator userValidator)
        {
            _userValidator = userValidator;
        }
        */

        [Theory(DisplayName = "Validate Valid User")]
        [Trait("Type", "User")]
        [InlineData("Tester","mail@mail.com", "validPassword1")]
        [InlineData("Tester With More Names", "mail@mail.net.br", "Validpassword2@#$")]
        public void Validate_ValidUser_MustBeValid(string username, string email, string password)
        {
            // Arrange
            var _userValidator = new UserValidator();

            var user = new User
            {
                Username = username,
                Email = email,
                Password = password
            };

            // Act
            var result = _userValidator.Validate(user);

            // Assert
            Assert.True(result.IsValid);
        }

        [Theory(DisplayName = "Validate Invalid User Password")]
        [Trait("Type", "User")]
        [InlineData("Tester", "mail@mail.com", "short")]
        [InlineData("Tester", "mail@mail.com", "RightSizeNoNumber")]
        [InlineData("Tester", "mail@mail.com", "rightsizenouppercase1")]
        [InlineData("Tester", "mail@mail.com", "RightParametersButTooLong1RightParametersButTooLong1RightParametersButTooLong1RightParametersButTooLong1")]
        public void Validate_InvalidUser_InvalidPassword(string username, string email, string password)
        {
            // Arrange
            var _userValidator = new UserValidator();

            var user = new User
            {
                Username = username,
                Email = email,
                Password = password
            };

            // Act
            var result = _userValidator.Validate(user);

            // Assert
            Assert.False(result.IsValid);
        }

        [Theory(DisplayName = "Validate Valid User")]
        [Trait("Type", "User")]
        [InlineData("User Name", "mail.net.br", "ValidPassword1")]
        [InlineData("User Name", "mail@@net.br", "ValidPassword1")]
        [InlineData("User Name", "@mail.net.br", "ValidPassword1")]
        public void Validate_InvalidUser_InvalidEmail(string username, string email, string password)
        {
            // Arrange
            var _userValidator = new UserValidator();

            var user = new User
            {
                Username = username,
                Email = email,
                Password = password
            };

            // Act
            var result = _userValidator.Validate(user);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
