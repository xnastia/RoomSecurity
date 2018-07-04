using System.Collections.Generic;
using Security.Entities;

namespace Security
{
    public static class SecurityLogic
    {
        public static void InitMonitors()
        {
            
        }
    }

    public class Model
    {
        private List<Monitor> monitors;

        private Model()
        {
            monitors = new List<Monitor>();
            var securityScanners = new List<SecurityScanner>()
            {
                //new SecurityScanner("Lobby", new Dictionary<BadgeType, List<AllowedTime>>(), )
            };
            monitors.Add(new Monitor(securityScanners));
        }

        public static Model GetModel()
        {
            return new Model();
        }
    }
}