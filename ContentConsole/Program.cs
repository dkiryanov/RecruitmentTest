using Services.Services.Implementations;
using Services.Services.Interfaces;
using System;

namespace ContentConsole
{
    public static class Program
    {
        //private IBannedWordService _bannedWordService = new BannedWordService();

        public static void Main(string[] args)
        {
            IBannedWordService _bannedWordService = new BannedWordService();

            Console.WriteLine("Input a path to file with bad words and press 'ENTER'");
            string pathToFile = Console.ReadLine();
            _bannedWordService.SetBannedWordsFromFile(pathToFile);


            string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            int bannedWords = _bannedWordService.GetBannedWordsCount(content);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + bannedWords);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
