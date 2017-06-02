using ContentConsole.DI;
using Ninject;
using Services.Services.Interfaces;
using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new ApplicationExportModule());
            var bannedWordService = kernel.Get<IBannedWordService>();

            ChangeTheSetOfBannedWords(bannedWordService);
            ScanContent(bannedWordService);
            PrintBannedWordsCount(bannedWordService);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        private static void ChangeTheSetOfBannedWords(IBannedWordService bannedWordService)
        {
            Console.WriteLine("To add bad words to list, input a path to file with bad words and press 'ENTER'.\n" +
                "If you do not want to to change the set of negative words, press 'ENTER'.");

            var pathToFile = Console.ReadLine();
            var result = bannedWordService.SetBannedWordsFromFile(pathToFile);

            if (!result.IsSuccessful)
            {
                Console.WriteLine(result.Error);
            }
        }

        private static void PrintBannedWordsCount(IBannedWordService bannedWordService)
        {
            var bannedWords = bannedWordService.GetBannedWordsCount();
            Console.WriteLine($"Total Number of negative words: {bannedWords}");
        }

        private static void ScanContent(IBannedWordService bannedWordService)
        {
            Console.WriteLine("Do you want to disable negative word filtering on the command line? Y / N:");
            var answer = Console.Read();

            Console.WriteLine("Scanned the text:");

            var shouldBeFiltered = answer == 'Y' || answer == 'y';

            Console.WriteLine(shouldBeFiltered
                ? bannedWordService.ScanContent()
                : bannedWordService.ScanContent(false));
        }
    }

}
