using System;
using Security.Entities;

namespace Security.BusinessLogic
{
    public interface ISecurityScanner
    {
        int ScannerId { get; }

        CheckerResponse CheckRoom(DateTime currentTime);

        bool IsBadgeAllowed(BadgeType badge, DateTime currentTime);

        bool IsSame(ISecurityScanner securityScanner);
    }
}