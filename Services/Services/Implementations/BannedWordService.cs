using DAL.UoW;
using Services.Services.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Services.Services.Implementations
{
    public sealed class BannedWordService : IBannedWordService
    {
        private const string Content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
        private readonly IUnitOfWork _uow;
        
        public BannedWordService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public SetBannedWordsResult SetBannedWordsFromFile(string pathToFile)
        {
            if (string.IsNullOrEmpty(pathToFile))
            {
                return new SetBannedWordsResult(false, "The file path is empty.", 0);
            }

            try
            { 
                using(var sr = new StreamReader(pathToFile))
                {
                    var bannedWords = sr.ReadToEnd().ToLower().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in bannedWords)
                    {
                        _uow.BannedWords().AddBannedWord(word);
                    }

                    return new SetBannedWordsResult(true, "Banned words were successfully added to storage.", bannedWords.Length);
                }
            }
            catch (Exception e)
            {
                return new SetBannedWordsResult(false, e.Message, 0);
            }
        }

        public int GetBannedWordsCount()
        {
            var content = GetScannedText();

            var bannedWords = _uow.BannedWords().GetBannedWords();

            return bannedWords.Count(word => content.ToLower().Contains(word.Key));
        }

        public string FilterBannedWords(string content)
        {
            var bannedWords = _uow.BannedWords().GetBannedWords();

            var builder = new StringBuilder(content);

            foreach(var word in bannedWords)
            {
                builder.Replace(word.Key, word.Value);
            }

            return builder.ToString();
        }

        public string ScanContent(bool withFiltration = true)
        {
            var content = GetScannedText();

            return !withFiltration ? content : FilterBannedWords(content);
        }

        /// <summary>
        /// This method immitates a text scanning process.
        /// </summary>
        private string GetScannedText()
        {
            return Content;
        }
    }
}
