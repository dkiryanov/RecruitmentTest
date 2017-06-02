using DAL.Repositories.Interfaces;

namespace DAL.UoW
{
    public interface IUnitOfWork
    {
        IBannedWordRepository BannedWords();
    }
}
