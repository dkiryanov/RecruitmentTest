using ContentStorage.Storage;
using System.Collections.Generic;

namespace DAL.Repositories.Implementations
{
    public class BannedWordRepository : IBannedWordRepository
    {
        public bool AddBannedWord(string word)
        {
            return WordStorage.AddWord(word);
        }

        public bool DeleteBannedWord(string word)
        {
            return WordStorage.DeleteWord(word);
        }

        public HashSet<string> GetBannedWords()
        {
            return WordStorage.GetWords();
        }
    }
}
