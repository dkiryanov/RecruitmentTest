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
            IBannedWordService _bannedWordService = kernel.Get<IBannedWordService>();

            ChangeTheSetOfBannedWords(_bannedWordService);
            ScanContent(_bannedWordService);
            PrintBannedWordsCount(_bannedWordService);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        private static void ChangeTheSetOfBannedWords(IBannedWordService bannedWordService)
        {
            Console.WriteLine("To add bad words to list, input a path to file with bad words and press 'ENTER'.\n" +
                "If you do not want to to change the set of negative words, press 'ENTER'.");

            string pathToFile = Console.ReadLine();
            bannedWordService.SetBannedWordsFromFile(pathToFile);
        }

        private static void PrintBannedWordsCount(IBannedWordService bannedWordService)
        {
            int bannedWords = bannedWordService.GetBannedWordsCount();
            Console.WriteLine($"Total Number of negative words: {bannedWords}");
        }

        private static void ScanContent(IBannedWordService bannedWordService)
        {
            Console.WriteLine("Do you want to disable negative word filtering on the command line? Y / N:");
            int answer = Console.Read();

            Console.WriteLine("Scanned the text:");

            bool shouldBeFiltered = answer == 'Y' || answer == 'y';

            if (shouldBeFiltered)
            {
                Console.WriteLine(bannedWordService.ScanContent());
            }
            else
            {
                Console.WriteLine(bannedWordService.ScanContent(false));
            }
        }
    }

}
