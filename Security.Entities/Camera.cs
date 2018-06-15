using System.Collections.Generic;

namespace Security.Entities
{
    public class Camera
    {
        public Camera(List<BadgeType> detectedBages)
        {
            DetectedBages = detectedBages;
        }

        public List<BadgeType> DetectedBages { get; set; }
    }
}