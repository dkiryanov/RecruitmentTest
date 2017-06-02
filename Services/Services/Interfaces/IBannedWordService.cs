using Services.Services.Implementations;

namespace Services.Services.Interfaces
{
    public interface IBannedWordService
    {
        int GetBannedWordsCount();
        SetBannedWordsResult SetBannedWordsFromFile(string pathToFile);
        string FilterBannedWords(string content);
        string ScanContent(bool withFiltration = true);
    }
}
