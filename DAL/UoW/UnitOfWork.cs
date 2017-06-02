using DAL.Repositories.Interfaces;

namespace DAL.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IBannedWordRepository _bannedWordRepository;

        public UnitOfWork(IBannedWordRepository bannedWordRepository)
        {
            _bannedWordRepository = bannedWordRepository;
        }

        public IBannedWordRepository BannedWords()
        {
            return _bannedWordRepository;
        }
    }
}
