using System.Collections.Generic;
using System.Linq;
using Security.Entities;

namespace Security.BusinessLogic
{
    public class MonitorSnapshot
    {
        public List<ScannerStatus> SecurityScannerStatuses { get; set; }

        public string CurrentTime { get; set; }

        public void UpdateStatus(CheckerResponse checkerResponse)
        {
            CurrentTime = checkerResponse.CheckTime.ToString("f");
            var securityScannerWithSameName = SecurityScannerStatuses.SingleOrDefault(x => x.Name == checkerResponse.ScannerName);

            if (securityScannerWithSameName == null)
            {
                securityScannerWithSameName = new ScannerStatus
                {
                    Name = checkerResponse.ScannerName
                };
                SecurityScannerStatuses.Add(securityScannerWithSameName);
            }

            securityScannerWithSameName.IsOk = !checkerResponse.IntruderFound;
        }
    }
}