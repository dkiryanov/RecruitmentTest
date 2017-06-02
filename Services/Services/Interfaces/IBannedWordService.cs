namespace Services.Services.Interfaces
{
    public interface IBannedWordService
    {
        int GetBannedWordsCount(string content);
        void SetBannedWordsFromFile(string pathToFile);
    }
}
