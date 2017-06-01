using ContentStorage.Storage;
using System.Collections.Generic;

namespace DAL.Repositories.Implementations
{
    public class BannedWordRepository : IBannedWordRepository
    {
        private readonly IWordStorage _storage;

        public BannedWordRepository(IWordStorage storage)
        {
            _storage = storage;
        }

        public bool AddBannedWord(string word)
        {
            return _storage.AddWord(word);
        }

        public bool DeleteBannedWord(string word)
        {
            return _storage.DeleteWord(word);
        }

        public HashSet<string> GetBannedWords()
        {
            return _storage.GetWords();
        }
    }
}
