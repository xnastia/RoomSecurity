using System.Collections.Generic;

namespace Security.Entities
{
    public interface IRecognizer
    {
        List<BadgeType> IdentifyBadges();
    }
}