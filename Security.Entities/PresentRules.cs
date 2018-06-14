
using System.Collections.Generic;

namespace Security.Entities
{
    public class PresentRule
    {
        public Dictionary<BadgeType, List<AllowedTime>> PresentRules { get; set; }

    }
}