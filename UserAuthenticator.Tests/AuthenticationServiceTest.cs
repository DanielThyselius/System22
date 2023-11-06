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

        [Fact]
        public void SendMailAfterSavingToDb()
        {
            // Arrange
            var name = "username";
            var email = "email@test.nu";

            var mockMailService = new Mock<IMailService>(MockBehavior.Strict);
            var mockDb = new Mock<IDatabase>(MockBehavior.Strict);

            var seq = new MockSequence();

            mockDb.InSequence(seq)
                .Setup(x => x.AddUser(It.IsAny<User>()))
                .Returns(true);

            mockMailService.InSequence(seq)
                .Setup(x => x.SendPassword(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            var sut = new AuthenticationService(mockMailService.Object, mockDb.Object);

            // Act
            var actual = sut.Register(name, email);
            
            // Assert

        }


        [Fact]
        public void LoginUserWorksWithCorrectPassword()
        {
            // Arrange
            var testPerson = new User()
            {
                Name = "username",
                Email = "email@test.nu",
                Password = "password"
            };

            var mockMailService = new Mock<IMailService>();
            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(x => x.GetUser(testPerson.Name)).Returns(testPerson);

            var sut = new AuthenticationService(mockMailService.Object, mockDb.Object);

            // Act
            var actual = sut.Login(testPerson.Name, testPerson.Password);

            // Assert
            mockDb.Verify(x => x.GetUser(testPerson.Name), Times.Once);
            Assert.True(actual);
        }

        [Fact]
        public void LoginUserFailsWithIncorrectPassword()
        {
            // Arrange
            var username = "username";
            var password = "password";

            var mockMailService = new Mock<IMailService>();
            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(x => x.GetUser(username)).Returns(
                new User
                {
                    Name = "username",
                    Email = "email@test.nu",
                    Password = "PassW0rd"
                });

            var sut = new AuthenticationService(mockMailService.Object, mockDb.Object);

            // Act
            var actual = sut.Login(username, password);

            // Assert
            mockDb.Verify(x => x.GetUser(username), Times.Once);
            Assert.False(actual);
        }

        [Fact]
        public void LoginUserFailsWithUnregisteredUsername()
        {
            // Arrange
            var username = "Unregistered";
            var password = "password";

            var mockMailService = new Mock<IMailService>();
            var mockDb = new Mock<IDatabase>();

            // User not found
            mockDb.Setup(x => x.GetUser(It.IsAny<string>())).Throws(
                new KeyNotFoundException());

            var sut = new AuthenticationService(mockMailService.Object, mockDb.Object);

            // Act
            var actual = sut.Login(username, password);

            // Assert
            Assert.False(actual);
        }



    }
}
