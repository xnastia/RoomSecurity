using System.Web.Http.Dependencies;
using Security.BusinessLogic;
using Security.DataLayer.EF;
using Security.Entities.DB;
using Unity;
using Unity.Lifetime;

namespace Security.WebApi.DependencyInjection
{
    public static class UnityDependencyResolver
    {
        public static IDependencyResolver CreateDependencyResolver()
        {
            var container = CreateUnityContainer();
            return new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static UnityContainer CreateUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<AlarmStatusRepository, AlarmStatusRepository>();
            container.RegisterType<IMonitorProvider, MonitorProvider>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISnapshotApi, SnapshotApi>();
            container.RegisterType<IAuthenticationProvider, AuthenticationProvider>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAlarmStatusRepository, DataLayer.EF.AlarmStatusRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICameraRepository, DataLayer.EF.CameraRepository>();
            container.RegisterType<ISecurityScannerProvider, SecurityScannerProvider>();
            container.RegisterType<IMonitorRepository, DataLayer.EF.MonitorRepository>();
            container.RegisterType<IPresenceRulesRepository, DataLayer.EF.PresenceRulesRepository>();
            container.RegisterType<IRoomRepository, DataLayer.EF.RoomRepository>();
            container.RegisterType<IUserRepository, DataLayer.EF.UserRepository>();
            container.RegisterType<IAlarmStatusProvider, AlarmStatusProvider>();
            container.RegisterType<ICameraProvider, CameraProvider>();
            container.RegisterType<IPresenceRulesProvider, PresenceRulesProvider>();
            container.RegisterType<IRoomProvider, RoomProvider>();
            container.RegisterType<IUserProvider, UserProvider>();
            container.RegisterType<ISnapshotProvider, SnapshotProvider>(new ContainerControlledLifetimeManager());
            return container;
        }
    }
}