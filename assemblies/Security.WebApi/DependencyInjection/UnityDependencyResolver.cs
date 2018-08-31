using System.Web.Http.Dependencies;
using Security.BusinessLogic;
using Security.DataLayer.EF;
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
            userRepository.AddUser("Ivan", "Ivanov", "ivanov@ukr.net", "1234");
            IUserProvider userProvider = new UserProvider(userRepository);
            container.RegisterInstance<ISnapshotApi>(snapshotApi);
            container.RegisterType<IAlarmStatusRepository, DataLayer.EF.AlarmStatusRepository>();
            container.RegisterType<ICameraRepository, DataLayer.EF.CameraRepository>();
            container.RegisterType<ISecurityScannerProvider, SecurityScannerProvider>();
            container.RegisterType<IMonitorRepository, DataLayer.EF.MonitorRepository>();
            container.RegisterType<IPresenceRulesRepository, DataLayer.EF.PresenceRulesRepository>();
            container.RegisterType<IRoomRepository, DataLayer.EF.RoomRepository>();
            container.RegisterType<IUserRepository, DataLayer.EF.UserRepository>();
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