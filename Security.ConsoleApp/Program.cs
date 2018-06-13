using System;
using System.Collections.Generic;
using Security.Entities;

namespace Security.Example
{
    class Program
    {
        static void Main()
        {
            RoomMonitor roomMonitor = new RoomMonitor();
            roomMonitor.Cameras = new List<Camera> { new Camera(new List<BageType> { BageType.Visitor, BageType.Support, BageType.Visitor } ),
                new Camera( new List<BageType> { BageType.Visitor, BageType.Support, BageType.Visitor, BageType.SecurityOfficer }),
                new Camera( new List<BageType>{ BageType.Visitor, BageType.Support, BageType.Visitor, BageType.SecurityOfficer }),
                new Camera( new List<BageType> { BageType.SecurityOfficer, BageType.Support, BageType.Visitor, BageType.SecurityOfficer })};
            Console.WriteLine(roomMonitor.IsIntruderInRoom(roomMonitor.Cameras));
            Console.ReadLine();
        }
    }
}