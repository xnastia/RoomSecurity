namespace Security.DataLayer.EF
{
    public class RoleMonitor
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int MonitorId { get; set; }
        public Monitor Monitor { get; set; }
    }
}