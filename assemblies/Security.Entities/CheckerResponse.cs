using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Entities
{
    public class CheckerResponse
    {
        public bool IntruderFound => Intruders == null || Intruders.Any();
        public List<BadgeType> Intruders { get; set; }

        public TimeSpan CheckTime { get; set; }
        
        public CheckerResponse(List<BadgeType> intruders, TimeSpan checkTime)
        {
            Intruders = intruders;
            CheckTime = checkTime;
        }
    }
}