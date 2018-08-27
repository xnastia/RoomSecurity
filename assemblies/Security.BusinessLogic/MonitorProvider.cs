using System;
using System.Collections.Generic;
using Security.DataLayer.EF;
using Security.Entities;
using Security.Entities.DB;

namespace Security.BusinessLogic
{
    public class MonitorProvider
    {
        private readonly Dictionary<int, Monitor> _monitors = new Dictionary<int, Monitor>();
        private readonly SecurityScannerProvider _securityScannerProvider = new SecurityScannerProvider();
        private IMonitorRepository _monitorRepository;

        public MonitorProvider(IMonitorRepository monitorRepository)
        {
            _monitorRepository = monitorRepository;
        }

        public MonitorProvider()
        {
            _monitorRepository = new MonitorRepository();
        }

        public Monitor GetMonitor(Guid uiId)
        {
            IMonitorRepository monitorRepository = new MonitorRepository();
            int monitorId = monitorRepository.GetMonitorIdByUiId(uiId);
            if (!_monitors.ContainsKey(monitorId))
            {
                var monitor = CreateMonitor(monitorId);
                _monitors.Add(monitorId, monitor);
                new SecurityDashboard(new TimerScanInvoker(), monitor).StartScanning();
            }
            return _monitors[monitorId];
        }
        
        public Monitor CreateMonitor(int monitorId)
        {
            IRecognizer recognizer = new RandomRecognizer(12121213);
            RoomProvider roomProvider = new RoomProvider();
            List<int> roomsIds = roomProvider.GetRoomsIdsByMonitorId(monitorId);
            var securitryScanners = new List<ISecurityScanner>();
            foreach (var roomId in roomsIds)
            {
                var roomScanner = _securityScannerProvider.GetRoomScanner(roomId, recognizer);
                securitryScanners.Add(roomScanner);
            }
            return new Monitor(securitryScanners);
        }

        public List<MonitorTab> GetMonitorsTabList()
        {
            IMonitorRepository monitorRepository = new MonitorRepository();
            return monitorRepository.GeMonitorTabs();
        }
    }
}