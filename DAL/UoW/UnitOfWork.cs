using ContentStorage.Storage;
using DAL.Repositories;
using DAL.Repositories.Implementations;
using System;

namespace DAL.UoW
{
    public sealed class UnitOfWork
    {
        private IBannedWordRepository _bannedWordRepository;

        public IBannedWordRepository BannedWords => _bannedWordRepository ?? (_bannedWordRepository = new BannedWordRepository());
    }
}
