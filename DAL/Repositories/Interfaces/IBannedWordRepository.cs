using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IBannedWordRepository
    {
        HashSet<string> GetBannedWords();
        bool AddBannedWord(string word);
        bool DeleteBannedWord(string word);
    }
}
