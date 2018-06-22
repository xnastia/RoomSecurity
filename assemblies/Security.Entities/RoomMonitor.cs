using System;
using System.Timers;

namespace Security.Entities
{
    public class RoomMonitor
    {
        private TimeSpan _currentTime; 
        private Timer _timer;
        private RoomSecurityChecker _roomSecurityChecker;

        public RoomMonitor(TimeSpan currentTime, RoomSecurityChecker roomChecker)
        {
            _currentTime = currentTime;
            _timer = new Timer();
            _roomSecurityChecker = roomChecker;
        }

        private void Timer()
        {
            _timer.Enabled = true;
            _timer.Interval = 1000;
            _timer.Elapsed += TimerOnElapsed;

            //Thread.Sleep(30000);
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            bool isIntruderInRoom = _roomSecurityChecker.IsIntruderInRoom(_currentTime);
            Console.WriteLine("Is intruder in room? {0}.",isIntruderInRoom);
            if (isIntruderInRoom)
            {
                BadgeType intruderBadge = GetIntruderBadgeType();
                Console.WriteLine(intruderBadge);
            }
            
            _currentTime += new TimeSpan(0, 30, 0);
        }

        public void Start()
        {
            Timer();
        }

        public void End()
        {
            
            _timer.Enabled = false;
        }

        private BadgeType GetIntruderBadgeType()
        {
            
            foreach (BadgeType badge in _roomSecurityChecker.PresenseRules.Keys)
            {
               if(!_roomSecurityChecker.IsBadgeAllowed(badge, _currentTime))
                {
                    return badge;
                }
            }
            return BadgeType.NoBadge;
        }

    }
}