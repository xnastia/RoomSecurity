using Ninject.Modules;
using Security.Entities.DB;

namespace Security.WebApi.Ninject
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            //Bind<IRoomRepository>().To<>();
        }
    }
}