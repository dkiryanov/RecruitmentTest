namespace Services.Services.Interfaces
{
    public interface IBannedWordService
    {
        int GetBannedWordsCount();
        void SetBannedWordsFromFile(string pathToFile);
        string FilterBannedWords(string content);
        string ScanContent(bool withFiltration = true);
    }
}
