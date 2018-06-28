using System;
using System.Collections.Generic;
using System.Linq;

namespace Security.Entities
{
    public class Alarmer
    {
        private readonly IAlarmMessageHandler _alarmMessageHandler;

        public Alarmer(IAlarmMessageHandler alarmMessageHandler)
        {
            if (alarmMessageHandler == null)
                throw new ArgumentNullException(nameof(alarmMessageHandler));

            _alarmMessageHandler = alarmMessageHandler;
        }

        public void OnIntruder(List<BadgeType> intruders)
        {
            if (intruders == null)
                throw new ArgumentNullException(nameof(intruders));

            if (!intruders.Any())
                return;
            var alarmMessages = CreateAlarmMessages(intruders);
            _alarmMessageHandler.HandleAlarmMessage(alarmMessages);
        }

        private List<string> CreateAlarmMessages(List<BadgeType> intruders)
        {
            var alarmMessages = new List<string>();
            foreach (var intruder in intruders)
                if (intruder == BadgeType.NoBadge)
                    alarmMessages.Add("Intruder in the room!");
                else
                    alarmMessages.Add(intruder + " not in allowed time.");
            return alarmMessages;
        }
    }
}