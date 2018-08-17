using System;
using System.Collections.Generic;
using System.Linq;
using Security.Entities;

namespace Security.BusinessLogic
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

        public void OnIntruderDetected(CheckerResponse checkerResponse)
        {
            if (checkerResponse.Intruders == null)
                throw new ArgumentNullException(nameof(checkerResponse.Intruders));

            if (!checkerResponse.Intruders.Any())
                return;
            var alarmMessages = CreateAlarmMessages(checkerResponse.Intruders);
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