using System.Collections.Generic;

namespace Security.BusinessLogic
{
    public interface IAlarmMessageHandler
    {
        void HandleAlarmMessage(List<string> alarmMessage);
    }
}