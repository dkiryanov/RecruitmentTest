using Services.Services.Implementations;
using Services.Services.Interfaces;
using System;

using System.Collections.Generic;

namespace ContentConsole
{
    public static class Program
    {
        //private IBannedWordService _bannedWordService = new BannedWordService();

        public static void Main(string[] args)
        {
            string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            IBannedWordService _bannedWordService = new BannedWordService();

            int bannedWords = _bannedWordService.GetBannedWordsCount(content);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + bannedWords);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
