using System;
using System.Collections.Generic;
using Security.Entities;

namespace Security.Example
{
    class Program
    {
        static void Main()
        {
            PresentRule presentRule = new PresentRule();
            Dictionary<BadgeType, List<AllowedTime>> presentRules = new Dictionary<BadgeType, List<AllowedTime>>();
            presentRules.Add(BadgeType.Visitor,new List<AllowedTime>() { new AllowedTime(new TimeSpan(10, 00, 00), new TimeSpan(15, 00, 00)) });
            presentRules.Add(BadgeType.Support, new List<AllowedTime>() { new AllowedTime(new TimeSpan(8, 00, 00), new TimeSpan(20, 00, 00)) });
            presentRules.Add(BadgeType.SecurityOfficer, new List<AllowedTime>() { new AllowedTime(new TimeSpan(00, 00, 00), new TimeSpan(00, 00, 00)) });
            RoomMonitor roomMonitor = new RoomMonitor();
            roomMonitor.Cameras = new List<Camera> { new Camera(new List<BadgeType> { BadgeType.Visitor, BadgeType.Support, BadgeType.Visitor } ),
                new Camera( new List<BadgeType> { BadgeType.Visitor, BadgeType.Support, BadgeType.Visitor, BadgeType.SecurityOfficer }),
                new Camera( new List<BadgeType>{ BadgeType.Visitor, BadgeType.Support, BadgeType.Visitor, BadgeType.SecurityOfficer }),
                new Camera( new List<BadgeType> { BadgeType.SecurityOfficer, BadgeType.Support, BadgeType.Visitor, BadgeType.SecurityOfficer })};
            Console.WriteLine(roomMonitor.IsIntruderInRoom(roomMonitor.Cameras,presentRules,new TimeSpan(17,00,00)));
            Console.ReadLine();
        }
    }
}