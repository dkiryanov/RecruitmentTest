using System;
using System.Collections.Generic;

namespace ContentStorage.Storage
{
    public interface IWordStorage : IDisposable
    {
        HashSet<string> GetWords();
        bool AddWord(string word);
        bool DeleteWord(string word);
    }
}
