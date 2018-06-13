using System;
using System.Collections.Generic;

namespace Security.Entities
{
    public class Camera
    {
        public List<BageType> DetectedBages { get; set; }
        public Camera(List<BageType> detectedBages)
        {
          
            this.DetectedBages = detectedBages;

        }
        public bool IsSafety()
        {
            bool result = true;
            foreach (BageType db in DetectedBages)
            {
                var person = Person.GetPersonByBadge(db);
                result = result &&person.IsPresentLegal(DateTime.Now.TimeOfDay);
            }
            return result;


        }

    }
}