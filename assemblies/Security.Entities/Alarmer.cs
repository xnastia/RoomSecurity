using System.Collections.Generic;

namespace Security.Entities
{
    public class Alarmer
    {
        public void OnIntruder(List<BadgeType> intruders)
        {
            string alarmMessage = CreateAlarmMessage(intruders);
            System.Console.WriteLine(alarmMessage);
        }
        public string CreateAlarmMessage( List<BadgeType> intruders)
        {
            string alarmMessage="";
            foreach (var intruder in intruders)
            {
                if (intruder == BadgeType.NoBadge)
                {
                    alarmMessage = "Intruder in the room!\n";
                }

                else
                {
                    alarmMessage += intruder + " not in allowed time.\n";
                }

            }
            return alarmMessage;
        }
    }
}