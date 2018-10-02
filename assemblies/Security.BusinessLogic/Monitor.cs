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

        public List<ISecurityScanner> SecurityScanners { get; set; }

        public Monitor(List<ISecurityScanner> securityScanners)
        {
            if (securityScanners == null)
                throw new ArgumentNullException(nameof(securityScanners));

            SecurityScanners = securityScanners;
        }

        public bool IsSame(IMonitor monitor)
        {
            var isSame = false;
            var numberOfSameScanners = 0;

            foreach (var scanner in SecurityScanners)
            {
                foreach (var comparedScanner in monitor.SecurityScanners)
                {
                    if (scanner.IsSame(comparedScanner))
                    {
                        numberOfSameScanners++;
                    }
                }
            }

            if (SecurityScanners.Count == numberOfSameScanners)
                isSame = true;

            return isSame;
        }

        public void Scan(DateTime currentTime)
        {
            foreach (var securityScanner in SecurityScanners)
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