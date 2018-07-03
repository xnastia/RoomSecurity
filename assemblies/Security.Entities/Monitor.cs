using System;
using System.Collections.Generic;

namespace Security.Entities
{
    public delegate void OnIntruderDelegate(List<BadgeType> intruders);

    public delegate void OnScanHandler(TimeSpan currentTime);

    public class Monitor
    {
        private readonly List<SecurityScanner> _securityScanners;

        public Monitor(List<SecurityScanner> securityScanners)
        {
            if (securityScanners == null)
                throw new ArgumentNullException(nameof(securityScanners));

            _securityScanners = securityScanners;
        }

        public event OnIntruderDelegate EventOnIntruder;

        public void Scan(TimeSpan currentTime)
        {
            foreach (var securityScanner in _securityScanners)
            {
                var checkerResponse = securityScanner.CheckRoom(currentTime);

                Console.WriteLine($"{currentTime}: Is intruder in room? {checkerResponse.IntruderFound}.");
                if (checkerResponse.IntruderFound)
                {
                    var intruders = checkerResponse.Intruders;
                    EventOnIntruder?.Invoke(intruders);
                }
            }
        }
    }
}