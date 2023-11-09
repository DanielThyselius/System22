using Moq;
using Todo.Cli;

namespace Todo.Tests
{
    public class UserInteractionTests
    {
        [Fact]
        public void GetInputWorksWhenUserInputsString()
        {
            // Arrange
            var mock = new Mock<IConsoleWrapper>();
            var expected = "Daniel";
            mock.Setup(x => x.ReadLine()).Returns(expected);
            var sut = new UserInteraction(mock.Object);

            // Act
            var actual = sut.GetInput("Vad heter du?");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetInputKeepsTryingOnEmpty()
        {
            // Arrange
            var mock = new Mock<IConsoleWrapper>();
            var expected = "Daniel";
            mock.SetupSequence(x => x.ReadLine())
                .Returns("")
                .Returns("")
                .Returns("")
                .Returns(expected);
            var sut = new UserInteraction(mock.Object);

            // Act
            var actual = sut.GetInput("Vad heter du?");

            // Assert
            Assert.Equal(expected, actual);
            mock.Verify(x => x.ReadLine(), Times.Exactly(4));
        }
    }
}