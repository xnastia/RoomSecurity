using System;
using System.Collections.Generic;

namespace Security.Entities
{
    public class Recognizer
    {
        private readonly Dictionary<BadgeType, int> _badgesWithOccurencePossibility;
        private int _chanceRange;

        public Recognizer()
        {
            _chanceRange = 1000;
            _badgesWithOccurencePossibility = new Dictionary<BadgeType, int>()
            {
                {BadgeType.Visitor, 100},
                {BadgeType.Support, 15},
                {BadgeType.SecurityOfficer, 10},
                {BadgeType.NoBadge, 1}

            };
        }

        public Recognizer(int chanceRange, Dictionary<BadgeType, int> badgesWithOccurencePossibility)
        {
            _chanceRange = chanceRange;
            _badgesWithOccurencePossibility = badgesWithOccurencePossibility;
        }

        private void AddRandomNumberOfBadgeType(List<BadgeType> detectedBadges, BadgeType badgeType)
        {
            Random randomNumberOfBadgeType = new Random();
            int chanceOfOccurence = _badgesWithOccurencePossibility[badgeType];
            int currentDice = randomNumberOfBadgeType.Next(_chanceRange);
            if(chanceOfOccurence >= currentDice)
            { 
                detectedBadges.Add(badgeType);
            }
        }

        public List<BadgeType> IdentifyBadges()
        {
            List<BadgeType> detectedBadges=new List<BadgeType>();
            var badgesList = Enum.GetValues(typeof(BadgeType));
            foreach (BadgeType badge in badgesList)
            {
                AddRandomNumberOfBadgeType(detectedBadges, badge);
            }

            return detectedBadges;
        }
    }
}
