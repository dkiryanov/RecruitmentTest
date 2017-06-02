using System;
using System.Collections.Generic;
using System.Text;

namespace ContentStorage.Storage
{
    public static class WordStorage
    {
        private static Dictionary<string, string> _bannedWords;

        static WordStorage()
        {
            _bannedWords = new Dictionary<string, string>();

            _bannedWords.Add("swine", HashBannedWord("swine"));
            _bannedWords.Add("bad", HashBannedWord("bad"));
            _bannedWords.Add("nasty", HashBannedWord("nasty"));
            _bannedWords.Add("horrible", HashBannedWord("horrible"));
        }
       
        public static void AddWord(string word)
        {
             _bannedWords.Add(word, HashBannedWord(word));
        }

        public static bool DeleteWord(string word)
        {
            return _bannedWords.Remove(word);
        }

        public static Dictionary<string, string> GetWords()
        {
            return _bannedWords;
        }

        private static string HashBannedWord(string word)
        {
            if (word.Length <= 2)
            {
                return "##";
            }

            StringBuilder builder = new StringBuilder(word);
            for(int i = 1; i < builder.Length - 1; i++)
            {
                builder.Replace(builder[i], '#');
            }

            return builder.ToString();
        }
    }
}
