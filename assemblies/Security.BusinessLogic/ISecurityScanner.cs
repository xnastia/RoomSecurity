using System;
using Security.Entities;

namespace Security.BusinessLogic
{
    public interface ISecurityScanner
    {
        string ScannerName { get; }

        CheckerResponse CheckRoom(DateTime currentTime);

        bool IsBadgeAllowed(BadgeType badge, DateTime currentTime);
    }
}