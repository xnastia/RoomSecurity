using System;
using System.Collections.Generic;

namespace Security.Entities
{
    public class RandomRecognizer : IRecognizer
    {
        private readonly Dictionary<BadgeType, int> _badgesWithOccurencePossibility;
        private readonly int _chanceRange;
        private readonly Random _randomNumberOfBadgeType;

        public RandomRecognizer(int seed)
        {
            _randomNumberOfBadgeType = new Random(seed);
            _chanceRange = 1000;
            _badgesWithOccurencePossibility = new Dictionary<BadgeType, int>
            {
                {BadgeType.Visitor, 1000},
                {BadgeType.Support, 1000},
                {BadgeType.SecurityOfficer, 10},
                {BadgeType.NoBadge, 1}
            };
        }

        public RandomRecognizer(int chanceRange, Dictionary<BadgeType, int> badgesWithOccurencePossibility)
        {
            _chanceRange = chanceRange;
            _badgesWithOccurencePossibility = badgesWithOccurencePossibility;
        }

        public List<BadgeType> IdentifyBadges()
        {
            var detectedBadges = new List<BadgeType>();
            var badgesList = Enum.GetValues(typeof(BadgeType));
            foreach (BadgeType badge in badgesList) AddRandomNumberOfBadgeType(detectedBadges, badge);

            return detectedBadges;
        }

        private void AddRandomNumberOfBadgeType(List<BadgeType> detectedBadges, BadgeType badgeType)
        {
            var chanceOfOccurence = _badgesWithOccurencePossibility[badgeType];
            var currentDice = _randomNumberOfBadgeType.Next(_chanceRange);
            if (chanceOfOccurence >= currentDice) detectedBadges.Add(badgeType);
        }
    }
}