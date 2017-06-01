using NUnit.Framework;
using Services.Services.Implementations;
using Services.Services.Interfaces;

namespace ContentConsole.Test.Unit.Tests
{
    [TestFixture]
    public class BannedWordServiceTest
    {
        private const string CONTENT = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

        [Test]
        public void BannedWordService_GetBannedWordsCount_Test()
        {
            //Arrange
            IBannedWordService service = new BannedWordService();

            //Act
            int bannedWordsCount = service.GetBannedWordsCount(CONTENT);

            //Assert
            Assert.AreEqual(2, bannedWordsCount);
        }
    }
}
