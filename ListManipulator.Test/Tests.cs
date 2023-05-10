using ListManipulator.App;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace ListManipulator.Test
{
    public class Tests
    {
        private IListManRepository _listMan;
        private ILogger _logger;
        private ListManService _sut;

        [SetUp]
        public void Setup()
        {
            _listMan = Substitute.For<IListManRepository>();
            _logger = Substitute.For<ILogger>();
            _sut = new ListManService(_listMan, _logger);
        }

        [Test]
        public void DivideTheInput_When_PrintIsCalled_Should_CallDivideTheInputMethod()
        {
            // Arrange
            _listMan.GetFinalList(Arg.Any<(List<int>, List<int>)>()).Returns(new List<string>());

            // Act
            _sut.Print("-4, 1");

            // Assert
            _listMan.ReceivedWithAnyArgs().DivideTheInput(Arg.Any<List<string>>());
        }

        [Test]
        public void GetFinalList_When_PrintIsCalled_Should_CallGetFinalListMethod()
        {
            // Arrange
            _listMan.DivideTheInput(Arg.Any<List<string>>()).Returns((new List<int> { -1 }, new List<int> { 3 }));
            _listMan.GetFinalList(Arg.Any<(List<int>, List<int>)>()).Returns((new List<string> { "-1", "|", "3" }));

            // Act
            _sut.Print("-1, 3");

            // Assert
            _listMan.ReceivedWithAnyArgs().GetFinalList(Arg.Any<(List<int>, List<int>)>());
        }

        [Test]
        public void LogInformation_When_PrintIsCalled_Should_CallLogInformationMethod()
        {
            // Arrange
            _listMan.GetFinalList(Arg.Any<(List<int>, List<int>)>()).Returns(new List<string>());

            // Act
            _sut.Print("1");

            // Assert
            _logger.Received().LogInformation(string.Empty);
        }

        [Test]
        public void LogInformation_When_PrintIsCalledWithNonNullString_Should_CallLogInformationMethod()
        {
            // Arrange
            _listMan.GetFinalList(Arg.Any<(List<int>, List<int>)>()).Returns(new List<string> { "-3", "-7", "|", "1", "4", "7", "100" });

            // Act
            _sut.Print("1");

            // Assert
            _logger.Received().LogInformation("-3, -7, |, 1, 4, 7, 100");
        }

        [Test]
        public void LogInformation_When_PrintIsCalledWithEmptyString_Should_NotCallLogInformationMethod()
        {
            // Arrange
            _listMan.GetFinalList(Arg.Any<(List<int>, List<int>)>()).Returns(new List<string>());

            // Act
            _sut.Print("");

            // Assert
            _logger.DidNotReceive().LogInformation(string.Empty);
        }

        [TestCase("")]
        [TestCase(null)]
        public void LogWarning_When_printIsCalledWithEmptyString_Should_NotCallLogWarningMethod(string input)
        {
            // Arrange
            _listMan.GetFinalList(Arg.Any<(List<int>, List<int>)>()).Returns(new List<string>());

            // Act
            _sut.Print(input);

            // Assert
            _logger.DidNotReceive().LogWarning(input);
        }
    }
}