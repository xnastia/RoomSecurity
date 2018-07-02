using System;
using System.Collections.Generic;
using System.Timers;

namespace Security.Entities
{
    public delegate void OnIntruderDelegate(List<BadgeType> intruders);

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

    public class ScanInvoker
    {
        private TimeSpan _currentTime;

        private readonly Timer _checkTimer;

        public ScanInvoker(TimeSpan currentTime)
        {
            if (currentTime > new TimeSpan(24, 0, 0))
                throw new ArgumentException($"The {nameof(currentTime)} should be in range 0 to 24 hours");
            _currentTime = currentTime;

            _checkTimer = new Timer();

        }

        private void Timer()
        {
            _checkTimer.Enabled = true;
            _checkTimer.Interval = 1000;
            _checkTimer.Elapsed += OnScan;
        }

        private void OnScan(object sender, ElapsedEventArgs e)
        {

            _currentTime += new TimeSpan(0, 30, 0);
        }

        public void Start()
        {
            Timer();
        }

        public void End()
        {
            _checkTimer.Enabled = false;
        }
    }

    public class SecurityDashboard
    {
        public SecurityDashboard()
        {
            IRecognizer recognizer = new RandomRecognizer(12121213);
            List<Camera> cameras = new List<Camera>()
            {
                new Camera()
            };
            SecurityScanner dinnerRoom = new SecurityScanner(new Dictionary<BadgeType, List<AllowedTime>>(), recognizer, cameras);
            SecurityScanner conferenceRoom = new SecurityScanner(new Dictionary<BadgeType, List<AllowedTime>>(), recognizer, cameras);
            SecurityScanner armoryRoom = new SecurityScanner(new Dictionary<BadgeType, List<AllowedTime>>(), recognizer, cameras);
            var securitryScanners = new List<SecurityScanner>
            {
                dinnerRoom,
                conferenceRoom,
                armoryRoom
            };

            Monitor monitor = new Monitor(securitryScanners);
        }
    }
}