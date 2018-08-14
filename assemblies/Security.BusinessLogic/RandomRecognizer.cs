using System;
using System.Collections.Generic;

namespace Security.BusinessLogic
{
    public class RandomRecognizer : IRecognizer
    {
        private readonly Dictionary<BadgeType, int> _badgesWithOccurencePossibility;
        private readonly int _chanceRange;
        private readonly Random _randomNumberOfBadgeType;
        private readonly int _delayResultChangeInSeconds;
        private DateTime _resultGeneratedDate = DateTime.Now;
        private readonly List<BadgeType> _detectedBadges = new List<BadgeType>();

        public RandomRecognizer(int seed, int delayResultChangeInSeconds = 60)
        {
            _delayResultChangeInSeconds = delayResultChangeInSeconds;
            _randomNumberOfBadgeType = new Random(seed);
            _chanceRange = 1000;
            _badgesWithOccurencePossibility = new Dictionary<BadgeType, int>
            {
                {BadgeType.Visitor, 100},
                {BadgeType.Support, 15},
                {BadgeType.SecurityOfficer, 10},
                {BadgeType.NoBadge, 1}
            };
        }

        public RandomRecognizer(int chanceRange, Dictionary<BadgeType, int> badgesWithOccurencePossibility, int delayResultChangeInSeconds = 60)
        {
            _chanceRange = chanceRange;
            _badgesWithOccurencePossibility = badgesWithOccurencePossibility;
            _delayResultChangeInSeconds = delayResultChangeInSeconds;
        }

        public List<BadgeType> IdentifyBadges(byte [] imageBytes)
        {
            return GetDetectedBadges();
        }

        private List<BadgeType> GetDetectedBadges()
        {
            if ((_resultGeneratedDate - DateTime.Now).TotalSeconds >= _delayResultChangeInSeconds)
            {
                _resultGeneratedDate = DateTime.Now;
                _detectedBadges.Clear();

                foreach (var badgePossibility in _badgesWithOccurencePossibility)
                {
                    var chanceOfOccurence = badgePossibility.Value;
                    var currentDice = _randomNumberOfBadgeType.Next(_chanceRange);
                    if (chanceOfOccurence >= currentDice)
                        _detectedBadges.Add(badgePossibility.Key);
                }
                
            }
            return _detectedBadges;
        }
    }
}