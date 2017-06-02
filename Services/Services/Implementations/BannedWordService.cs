using DAL.UoW;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Services.Services.Implementations
{
    public sealed class BannedWordService : IBannedWordService
    {
        private readonly UnitOfWork _uow;

        public BannedWordService()
        {
            _uow = new UnitOfWork();
        }

        public void SetBannedWordsFromFile(string pathToFile)
        {
            if (string.IsNullOrEmpty(pathToFile))
            {
                return;
            }

            try
            { 
                using(StreamReader sr = new StreamReader(pathToFile))
                {
                    string[] bannedWords = sr.ReadToEnd().ToLower().Split(',');

                    foreach (string word in bannedWords)
                    {
                        _uow.BannedWords.AddBannedWord(word);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetBannedWordsCount(string content)
        {
            HashSet<string> bannedWords = _uow.BannedWords.GetBannedWords();

            int badWords = 0;

            foreach (string word in bannedWords)
            {
                if (content.ToLower().Contains(word))
                {
                    badWords++;
                }
            }

            return badWords;
        }
    }
}
