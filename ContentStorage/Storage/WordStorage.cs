using System;
using System.Collections.Generic;

namespace ContentStorage.Storage
{
    public class WordStorage : IWordStorage
    {
        private bool _disposed;
        private HashSet<string> _bannedWords;

        public WordStorage()
        {
            _bannedWords = new HashSet<string>() { "swine", "bad", "nasty", "horrible" };
        }
       
        public bool AddWord(string word)
        {
            return _bannedWords.Add(word);
        }

        public bool DeleteWord(string word)
        {
            return _bannedWords.Remove(word);
        }

        public HashSet<string> GetWords()
        {
            return _bannedWords;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _bannedWords.Clear();
            }
            _disposed = true;
        }
    }
}
