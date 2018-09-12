using System.Web.Http.Dependencies;
using Security.BusinessLogic;
using Security.DataLayer;
using Security.Entities.DB;
using Unity;

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
            MonitorRepository monitorRepository = new MonitorRepository();
            RoomRepository roomRepository = new RoomRepository();
            RoomProvider roomProvider = new RoomProvider(roomRepository);
            CameraRepository cameraRepository = new CameraRepository();
            CameraProvider cameraProvider = new CameraProvider(cameraRepository);
            PresenceRulesRepository presenceRulesRepository = new PresenceRulesRepository();
            PresenceRulesProvider presenceRulesProvider = new PresenceRulesProvider(presenceRulesRepository);
            SecurityScannerProvider securityScannerProvider =
            new SecurityScannerProvider(cameraProvider, presenceRulesProvider);
            MonitorProvider monitorProvider = new MonitorProvider(monitorRepository, roomProvider, securityScannerProvider);
            AlarmStatusRepository alarmStatusRepository = new AlarmStatusRepository();
            AlarmStatusProvider alarmStatusProvider = new AlarmStatusProvider(alarmStatusRepository);
            SnapshotProvider snapshotProvider = new SnapshotProvider(alarmStatusProvider);
            ISnapshotApi snapshotApi = new SnapshotApi(monitorProvider, snapshotProvider);
            IUserRepository userRepository = new UserRepository();
            IAuthenticationProvider authenticationProvider = new AuthenticationProvider();
            userRepository.AddUser("Sidor", "Sidorov", "sidorov@ukr.net", "9012");
            IUserProvider userProvider = new UserProvider(userRepository);
            container.RegisterInstance<ISnapshotApi>(snapshotApi);
            container.RegisterInstance<IAuthenticationProvider>(authenticationProvider);
            container.RegisterType<IAlarmStatusRepository, DataLayer.AlarmStatusRepository>();
            container.RegisterType<ICameraRepository, DataLayer.CameraRepository>();
            container.RegisterType<ISecurityScannerProvider, SecurityScannerProvider>();
            container.RegisterType<IMonitorRepository, DataLayer.MonitorRepository>();
            container.RegisterType<IPresenceRulesRepository, DataLayer.PresenceRulesRepository>();
            container.RegisterType<IRoomRepository, DataLayer.RoomRepository>();
            container.RegisterType<IUserRepository, DataLayer.UserRepository>();
            container.RegisterType<IAlarmStatusProvider, AlarmStatusProvider>();
            container.RegisterType<ICameraProvider, CameraProvider>();
            container.RegisterType<IMonitorProvider, MonitorProvider>();
            container.RegisterType<IPresenceRulesProvider, PresenceRulesProvider>();
            container.RegisterType<IRoomProvider, RoomProvider>();
            container.RegisterType<IUserProvider, UserProvider>();
            container.RegisterType<ISnapshotProvider, SnapshotProvider>();
            return container;
        }
    }
}