using System.Collections.Generic;

namespace Security.Entities
{
    public interface IAlarmMessageHandler
    {
        void HandleAlarmMessage(List<string> alarmMessage);
    }
}