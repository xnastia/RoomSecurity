using System.Collections.Generic;
using Security.Entities;

namespace Security.BusinessLogic
{
    public interface IRecognizer
    {
        List<BadgeType> IdentifyBadges(byte[] imageBytes);
    }
}