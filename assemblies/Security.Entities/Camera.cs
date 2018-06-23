using System.Collections.Generic;

namespace Security.Entities
{
    public class Camera
    {
        private Recognizer Recognizer;

        public List<BadgeType> DetectedBages { get; set; }

        public Camera()
        {
            Recognizer=new Recognizer();
            DetectedBages= Recognizer.IdentifyBadges();
        }
      }
}