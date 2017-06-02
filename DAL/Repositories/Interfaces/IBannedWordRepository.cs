using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IBannedWordRepository
    {
        Dictionary<string, string> GetBannedWords();
        void AddBannedWord(string word);
        void DeleteBannedWord(string word);
    }
}
