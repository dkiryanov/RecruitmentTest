using System;
using System.Collections.Generic;

namespace ContentStorage.Storage
{
    public static class WordStorage
    {
        private static HashSet<string> _bannedWords;

        static WordStorage()
        {
            _bannedWords = new HashSet<string>() { "swine", "bad", "nasty", "horrible" };
        }
       
        public static bool AddWord(string word)
        {
            return _bannedWords.Add(word);
        }

        public static bool DeleteWord(string word)
        {
            return _bannedWords.Remove(word);
        }

        public static HashSet<string> GetWords()
        {
            return _bannedWords;
        }
    }
}
