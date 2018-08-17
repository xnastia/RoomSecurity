using System;
using Security.Entities;

namespace Security.BusinessLogic
{
    public interface ISecurityScanner
    {
        string ScannerName { get; }

        CheckerResponse CheckRoom(TimeSpan currentTime);

        bool IsBadgeAllowed(BadgeType badge, TimeSpan currentTime);
    }
}