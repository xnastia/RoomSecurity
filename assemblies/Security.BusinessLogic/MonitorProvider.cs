using System;
using System.Collections.Generic;
using Security.DataLayer;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class MonitorProvider
    {
        private static readonly Dictionary<int, Monitor> Monitors = new Dictionary<int, Monitor>();

        private readonly SecurityScannerProvider _securityScannerProvider = new SecurityScannerProvider();
        
        public Monitor GetMonitor(Guid uiId)
        {
            MonitorRepository monitorRepository = new MonitorRepository();
            int monitorId = monitorRepository.GetMonitorIdByUiId(uiId);
            if (!Monitors.ContainsKey(monitorId))
            {
                var monitor = CreateMonitor(monitorId);
                new SecurityDashboard(new TimerScanInvoker(), monitor).StartScanning();
                Monitors.Add(monitorId, monitor);
            }
            return Monitors[monitorId];
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
            MonitorRepository monitorRepository = new MonitorRepository();
            return monitorRepository.GeMonitorTabs();
        }
    }
}