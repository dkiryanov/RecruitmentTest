using System.Collections.Generic;
using System.Text;

namespace ContentStorage.Storage
{
    public static class WordStorage
    {
        private static readonly Dictionary<string, string> BannedWords;
        private const char HashSymbol = '#';
        private const string DefaultHash = "##";

        static WordStorage()
        {
            BannedWords = new Dictionary<string, string>
            {
                {"swine", HashBannedWord("swine")},
                {"bad", HashBannedWord("bad")},
                {"nasty", HashBannedWord("nasty")},
                {"horrible", HashBannedWord("horrible")}
            };
        }
       
        public static void AddWord(string word)
        {
            if (BannedWords.ContainsKey(word))
            {
                return;
            }

            BannedWords.Add(word, HashBannedWord(word));
        }

        public static bool DeleteWord(string word)
        {
            return BannedWords.Remove(word);
        }

        public static Dictionary<string, string> GetWords()
        {
            return BannedWords;
        }

        private static string HashBannedWord(string word)
        {
            if (word.Length <= 2)
            {
                return DefaultHash;
            }

            var builder = new StringBuilder(word);
            for(var i = 1; i < builder.Length - 1; i++)
            {
                builder.Replace(builder[i], HashSymbol);
            }

            return builder.ToString();
        }
    }
}
