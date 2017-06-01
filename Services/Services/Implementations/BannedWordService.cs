using DAL.UoW;
using Services.Services.Interfaces;
using System.Collections.Generic;

namespace Services.Services.Implementations
{
    public sealed class BannedWordService : IBannedWordService
    {
        public int GetBannedWordsCount(string content)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                HashSet<string> bannedWords = uow.BannedWords.GetBannedWords();

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
}
