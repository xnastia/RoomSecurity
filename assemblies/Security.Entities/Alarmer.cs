namespace Security.Entities
{
    public class Alarmer
    {
        public string CreateAlarmMessage(RoomSecurityChecker roomSecurityChecker, BadgeType badgeType)
        {
            string alarmMessage;
            if (badgeType == BadgeType.NoBadge)
                alarmMessage = "Intruder in the room!";
            alarmMessage = badgeType + "not in allowed time. Allowed hours are ";
            var allowedTimes = roomSecurityChecker.PresenseRules[badgeType];
            foreach (var allowedTime in allowedTimes)
                alarmMessage += "from " + allowedTime.StartTime + " to " + allowedTime.EndTime;
            return alarmMessage;
        }
    }
}