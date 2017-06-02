namespace Services.Services.Implementations
{
    public class SetBannedWordsResult
    {
        public SetBannedWordsResult(bool isSuccessful, string error, int addedWordsCount)
        {
            IsSuccessful = isSuccessful;
            Error = error;
            AddedWordsCount = addedWordsCount;
        }

        public bool IsSuccessful { get; }
        public string Error { get; }
        public int AddedWordsCount { get; }
    }
}

