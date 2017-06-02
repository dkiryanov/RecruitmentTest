using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using DAL.UoW;
using Ninject.Modules;
using Services.Services.Implementations;
using Services.Services.Interfaces;

namespace ContentConsole.DI
{
    public class ApplicationExportModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IBannedWordRepository)).To(typeof(BannedWordRepository));
            Bind(typeof(IUnitOfWork)).To(typeof(UnitOfWork));
            Bind(typeof(IBannedWordService)).To(typeof(BannedWordService));
        }
    }
}
