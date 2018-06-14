using System.Collections.Generic;
using System.Runtime.Remoting.Channels;

namespace Security.Entities
{
    public class Camera
    {
        public List<BadgeType> DetectedBadges { get; set; }
        public Camera(List<BadgeType> detectedBadges)
        {
           DetectedBadges = detectedBadges;
           
        }
      }

}