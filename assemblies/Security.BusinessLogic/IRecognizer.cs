using System.Collections.Generic;

namespace Security.BusinessLogic
{
    public interface IRecognizer
    {
        List<BadgeType> IdentifyBadges(byte[] imageBytes);
    }
}