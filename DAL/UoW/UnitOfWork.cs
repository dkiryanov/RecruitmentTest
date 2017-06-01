using ContentStorage.Storage;
using DAL.Repositories;
using DAL.Repositories.Implementations;
using System;

namespace DAL.UoW
{
    public sealed class UnitOfWork : IDisposable
    {
        private bool _disposed;
        private readonly IWordStorage _storage;
        private IBannedWordRepository _bannedWordRepository;

        public UnitOfWork()
        {
            _storage = new WordStorage();
        }

        public IBannedWordRepository BannedWords => _bannedWordRepository ?? (_bannedWordRepository = new BannedWordRepository(_storage));

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _storage.Dispose();
            }
            _disposed = true;
        }
    }
}
