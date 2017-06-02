using Ninject.Modules;
using Services.Services.Implementations;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.DI
{
    public class ApplicationExportModule : NinjectModule
    {
        public override void Load()
        {
            //Bind(Type.GetType("DI.Data.DIConsoleEntities, DI.Data")).ToSelf().InSingletonScope();
            Bind(typeof(IBannedWordService)).To(typeof(BannedWordService)).InSingletonScope();
        }
    }
}
