using ContentStorage.Storage;
using System.Collections.Generic;

namespace DAL.Repositories.Implementations
{
    public class BannedWordRepository : IBannedWordRepository
    {
        public void AddBannedWord(string word)
        {
            WordStorage.AddWord(word);
        }

        public void DeleteBannedWord(string word)
        {
            WordStorage.DeleteWord(word);
        }

        public Dictionary<string, string> GetBannedWords()
        {
            return WordStorage.GetWords();
        }
    }
}
