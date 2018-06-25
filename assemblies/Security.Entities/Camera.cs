using System.Collections.Generic;

namespace Security.Entities
{
    public class Camera
    {
        private Recognizer Recognizer;

        public List<BadgeType> DetectedBadges { get; set; }

        public Camera()
        {
            Recognizer=new Recognizer();
            DetectedBadges= Recognizer.IdentifyBadges();
        }

        public Camera(Recognizer recognizer)
        {
            Recognizer = recognizer;
            DetectedBadges = Recognizer.IdentifyBadges();
        }

      }
}