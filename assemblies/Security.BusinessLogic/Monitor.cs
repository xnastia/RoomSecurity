using System;
using System.Collections.Generic;

namespace Security.BusinessLogic
{
    public delegate void CheckDoneHandler(CheckerResponse checkerResponse);

    public delegate void OnScanHandler(DateTime currentTime);

    public class Monitor : IMonitor
    {
        public event CheckDoneHandler EventOnIntruderDetected;
        public event CheckDoneHandler EventOnCheckDone;

        private readonly List<ISecurityScanner> _securityScanners;

        public Monitor(List<ISecurityScanner> securityScanners)
        {
            if (securityScanners == null)
                throw new ArgumentNullException(nameof(securityScanners));

            _securityScanners = securityScanners;
        }

        public void Scan(DateTime currentTime)
        {
            foreach (var securityScanner in _securityScanners)
            {
                var checkerResponse = securityScanner.CheckRoom(currentTime);

                EventOnCheckDone?.Invoke(checkerResponse);

                if (checkerResponse.IntruderFound)
                {
                    EventOnIntruderDetected?.Invoke(checkerResponse);
                }
            }
        }
    }
}