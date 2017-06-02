using NUnit.Framework;
using Services.Services.Implementations;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using DAL.Repositories.Interfaces;
using Moq;
using DAL.UoW;

namespace ContentConsole.Test.Unit.Tests
{
    [TestFixture]
    public class BannedWordServiceTest
    {
        private const string Content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
        private const string FilteredContent = "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.";
        private const int BadWordsCountByDefault = 2;

        private readonly Dictionary<string, string> _bannedWords = new Dictionary<string, string>
        {
            {"swine", "s###e"},
            {"bad", "b#d"},
            {"nasty", "n###y"},
            {"horrible", "h######e"}
        };

        [Test]
        public void BannedWordService_GetBannedWordsCount_ReturnsCorrectCount()
        {
            //Arrange
            var repositoryMock = new Mock<IBannedWordRepository>();
            repositoryMock.Setup(r => r.GetBannedWords()).Returns(_bannedWords);

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(w => w.BannedWords()).Returns(repositoryMock.Object);

            IBannedWordService service = new BannedWordService(uowMock.Object);

            //Act
            var bannedWordsCount = service.GetBannedWordsCount();

            //Assert
            Assert.AreEqual(BadWordsCountByDefault, bannedWordsCount);
        }

        [Test]
        public void BannedWordService_SetBannedWordsFromFile_ReturnsBadWordsCountWithWordsFromFile()
        {
            //Arrange
            var repositoryMock = new Mock<IBannedWordRepository>();
            repositoryMock.Setup(r => r.GetBannedWords()).Returns(_bannedWords);

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(w => w.BannedWords()).Returns(repositoryMock.Object);

            IBannedWordService service = new BannedWordService(uowMock.Object);
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}words.txt";
            service.SetBannedWordsFromFile(path);

            //Act
            service.GetBannedWordsCount();

            //Assert
            repositoryMock.Verify(m => m.AddBannedWord(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void BannedWordService_FilterBannedWords_ReturnsFilteredContent()
        {
            //Arrange
            var repositoryMock = new Mock<IBannedWordRepository>();
            repositoryMock.Setup(r => r.GetBannedWords()).Returns(_bannedWords);

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(w => w.BannedWords()).Returns(repositoryMock.Object);

            IBannedWordService service = new BannedWordService(uowMock.Object);

            //Act
            var filteredContent = service.FilterBannedWords(Content);

            //Assert
            Assert.AreEqual(FilteredContent, filteredContent);
        }

        [Test]
        public void BannedWordService_ScanContent_WhithFiltration_ReturnsFilteredContent()
        {
            //Arrange
            var repositoryMock = new Mock<IBannedWordRepository>();
            repositoryMock.Setup(r => r.GetBannedWords()).Returns(_bannedWords);

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(w => w.BannedWords()).Returns(repositoryMock.Object);

            IBannedWordService service = new BannedWordService(uowMock.Object);

            //Act
            var scannedText = service.ScanContent();

            //Assert
            Assert.AreEqual(FilteredContent, scannedText);
        }

        [Test]
        public void BannedWordService_ScanContent_WhithoutFiltration_ReturnsNotFilteredContent()
        {
            //Arrange
            var repositoryMock = new Mock<IBannedWordRepository>();
            repositoryMock.Setup(r => r.GetBannedWords()).Returns(_bannedWords);

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(w => w.BannedWords()).Returns(repositoryMock.Object);

            IBannedWordService service = new BannedWordService(uowMock.Object);

            //Act
            var scannedText = service.ScanContent(false);

            //Assert
            Assert.AreEqual(Content, scannedText);
        }
    }
}
