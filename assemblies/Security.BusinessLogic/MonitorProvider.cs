using System;
using System.Collections.Generic;
using Security.Entities;
using Security.Entities.DB;

namespace Security.BusinessLogic
{
    public class MonitorProvider : IMonitorProvider
    {
        private readonly Dictionary<int, Monitor> _monitors = new Dictionary<int, Monitor>();
        private readonly ISecurityScannerProvider _securityScannerProvider;
        private IMonitorRepository _monitorRepository;
        private IRoomProvider _roomProvider;

        public MonitorProvider(IMonitorRepository monitorRepository, IRoomProvider roomProvider,
            ISecurityScannerProvider securityScannerProvider)
        {
            _monitorRepository = monitorRepository;
            _roomProvider = roomProvider;
            _securityScannerProvider = securityScannerProvider;
        }
        
        public Monitor GetMonitor(Guid uiId)
        {
            int? monitorId = _monitorRepository.GetMonitorIdByUiId(uiId);

            if (!monitorId.HasValue)
                return null;

            if (!_monitors.ContainsKey(monitorId.Value))
            {
                var monitor = CreateMonitor(monitorId.Value);
                _monitors.Add(monitorId.Value, monitor);
                var timerScanInvoker = new TimerScanInvoker();
                new SecurityDashboard(timerScanInvoker, monitor).StartScanning();
            }
            return _monitors[monitorId.Value];
        }
        
        public Monitor CreateMonitor(int monitorId)
        {
            IRecognizer recognizer = new RandomRecognizer(12121213);
            List<int> roomsIds = _roomProvider.GetRoomsIdsByMonitorId(monitorId);
            var securitryScanners = new List<ISecurityScanner>();
            foreach (var roomId in roomsIds)
            {
                var roomScanner = _securityScannerProvider.GetRoomScanner(roomId, recognizer);
                securitryScanners.Add(roomScanner);
            }
            return new Monitor(securitryScanners);
        }

        public List<MonitorTab> GetMonitorsTabList(string user)
        {
            return _monitorRepository.GeMonitorTabs(user);
        }
    }
}