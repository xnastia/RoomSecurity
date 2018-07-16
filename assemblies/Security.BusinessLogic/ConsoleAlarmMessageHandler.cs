using System;
using System.Collections.Generic;

namespace Security.BusinessLogic
{
    public class ConsoleAlarmMessageHandler : IAlarmMessageHandler
    {
        public void HandleAlarmMessage(List<string> alarmMessages)
        {
            foreach (var alarmMessage in alarmMessages) Console.WriteLine(alarmMessage);
        }
    }
}