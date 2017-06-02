using NUnit.Framework;
using Services.Services.Implementations;
using Services.Services.Interfaces;
using System;

namespace ContentConsole.Test.Unit.Tests
{
    [TestFixture]
    public class BannedWordServiceTest
    {
        private const string CONTENT = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
        private const int BAD_WORDS_COUNT_BY_DEFAULT = 2;
        private const int BAD_WORDS_COUNT_WITH_FILE_SETTING = 3;

        [Test]
        public void BannedWordService_GetBannedWordsCount_Test()
        {
            //Arrange
            IBannedWordService service = new BannedWordService();

            //Act
            int bannedWordsCount = service.GetBannedWordsCount(CONTENT);

            //Assert
            Assert.AreEqual(BAD_WORDS_COUNT_BY_DEFAULT, bannedWordsCount);
        }

        [Test]
        public void BannedWordService_SetBannedWordsFromFile_Test()
        {
            //Arrange
            IBannedWordService service = new BannedWordService();
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}words.txt";
            service.SetBannedWordsFromFile(path);

            //Act
            int bannedWordsCount = service.GetBannedWordsCount(CONTENT);

            //Assert
            Assert.AreEqual(BAD_WORDS_COUNT_WITH_FILE_SETTING, bannedWordsCount);
        }
    }
}
