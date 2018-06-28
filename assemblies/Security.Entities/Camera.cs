using System.Collections.Generic;

namespace Security.Entities
{
    public class Camera
    {
        private readonly IRecognizer Recognizer;

        public Camera(IRecognizer recognizer)
        {
            Recognizer = recognizer;
        }

        public List<BadgeType> DetectedBadges => Recognizer.IdentifyBadges();
    }
}