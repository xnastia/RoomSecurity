using Ninject.Modules;
using Security.BusinessLogic;

namespace Security.WebApi.Ninject
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            SnapshotApi sn = new SnapshotApi();
            Bind<ISnapshotApi>().ToConstant(sn);
            //Bind<ISnapshotApi>().To<SnapshotApi>().InSingletonScope();
        }
    }
}