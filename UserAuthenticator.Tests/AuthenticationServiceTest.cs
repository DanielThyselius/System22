using Moq;

namespace UserAuthenticator.Tests
{
    public class AuthenticationServiceTest
    {

        [Fact]
        public void CanRegisterUser() { 
            // Arrange
            var name = "username";
            var email = "email@test.nu";

            var mockMailService = new Mock<IMailService>();
            var mockDb = new Mock<IDatabase>();
            
            var sut = new AuthenticationService(mockMailService.Object, mockDb.Object);

            // Act
            var actual = sut.Register(name, email);

            // Assert
            Assert.NotEqual(Guid.Empty, actual.UserId);
            Assert.Equal(name, actual.Name);
            Assert.Equal(email, actual.Email);
            Assert.NotEmpty(actual.Password);

        }

        [Fact]
        public void RegisterUserAddsItToDb()
        {
            // Arrange
            var name = "username";
            var email = "email@test.nu";

            var mockMailService = new Mock<IMailService>();
            var mockDb = new Mock<IDatabase>();

            var sut = new AuthenticationService(mockMailService.Object, mockDb.Object);

            // Act
            var actual = sut.Register(name, email);

            // Assert
            mockDb.Verify(x => x.AddUser(actual), Times.Once());
        }


        [Fact]
        public void PasswordIsEmailedWhenRegistering() {
            // Arrange
            var name = "username";
            var email = "email@test.nu";

            var mockMailService = new Mock<IMailService>();
            var mockDb = new Mock<IDatabase>();

            var sut = new AuthenticationService(mockMailService.Object, mockDb.Object);

            // Act
            var actual = sut.Register(name, email);

            // Assert
            mockMailService.Verify(x => x.SendPassword(email, actual.Password), Times.Once);
        }



    }
}
