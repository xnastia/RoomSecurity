using System;
using System.Collections.Generic;

namespace Security.Entities
{
    public delegate void CheckDoneHandler(CheckerResponse checkerResponse);

    public delegate void OnScanHandler(TimeSpan currentTime);

    public class Monitor
    {
        public event CheckDoneHandler EventOnIntruderDetected;
        public event CheckDoneHandler EventOnCheckDone;

        private readonly List<SecurityScanner> _securityScanners;

        public Monitor(List<SecurityScanner> securityScanners)
        {
            if (securityScanners == null)
                throw new ArgumentNullException(nameof(securityScanners));

            _securityScanners = securityScanners;
        }

        public void Scan(TimeSpan currentTime)
        {
            foreach (var securityScanner in _securityScanners)
            {
                var checkerResponse = securityScanner.CheckRoom(currentTime);

                EventOnCheckDone?.Invoke(checkerResponse);

                //Console.WriteLine($"{currentTime}: Is intruder in room? {checkerResponse.IntruderFound}.");
                if (checkerResponse.IntruderFound)
                {
                    EventOnIntruderDetected?.Invoke(checkerResponse);
                }
            }
         }
    }
}