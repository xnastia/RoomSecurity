using System;
using System.Collections.Generic;
using System.Timers;

namespace Security.Entities
{
    public class RoomMonitor
    {
        public delegate void OnIntruderDelegate(List<BadgeType> intruders);

        public RoomMonitor(TimeSpan currentTime, RoomSecurityChecker roomChecker)
        {
            if (currentTime > new TimeSpan(24, 0, 0))
                throw new ArgumentException($"The {nameof(currentTime)} should be in range 0 to 24 hours");
            CurrentTime = currentTime;
            CheckTimer = new Timer();
            if (roomChecker == null)
                throw new ArgumentNullException(nameof(roomChecker));
            RoomChecker = roomChecker;
        }

        private TimeSpan CurrentTime { get; set; }
        private Timer CheckTimer { get; }
        private RoomSecurityChecker RoomChecker { get; }
        public bool TimerEnabled => CheckTimer.Enabled;
        public event OnIntruderDelegate EventOnIntruder;

        private void Timer()
        {
            CheckTimer.Enabled = true;
            CheckTimer.Interval = 1000;
            CheckTimer.Elapsed += TimerOnElapsed;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            var checkerResponse = RoomChecker.CheckRoom(CurrentTime);

            Console.WriteLine($"{CurrentTime}: Is intruder in room? {checkerResponse.IntruderFound}.");
            if (checkerResponse.IntruderFound)
            {
                var intruders = checkerResponse.Intruders;
                EventOnIntruder(intruders);
            }

            CurrentTime += new TimeSpan(0, 30, 0);
        }

        public void Start()
        {
            Timer();
        }

        public void End()
        {
            CheckTimer.Enabled = false;
        }
    }
}