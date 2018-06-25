using System;
using System.Collections.Generic;
using System.Timers;

namespace Security.Entities
{
    public class RoomMonitor
    {
        

        public RoomMonitor(TimeSpan currentTime, RoomSecurityChecker roomChecker)
        {
            CurrentTime = currentTime;
            CheckTimer = new Timer();
            RoomChecker = roomChecker;
        }

        private TimeSpan CurrentTime { get; set; }
        private Timer CheckTimer { get; }
        private RoomSecurityChecker RoomChecker { get; }
        public delegate void OnIntruderDelegate(List<BadgeType> intruders);
        public event OnIntruderDelegate EventOnIntruder;

        private void Timer()
        {
            CheckTimer.Enabled = true;
            CheckTimer.Interval = 1000;
            CheckTimer.Elapsed += TimerOnElapsed;

            //Thread.Sleep(30000);
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            var checkerResponse = RoomChecker.IsIntruderInRoom(CurrentTime);

            Console.WriteLine("Is intruder in room? {0}.", checkerResponse.IntruderFound);
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