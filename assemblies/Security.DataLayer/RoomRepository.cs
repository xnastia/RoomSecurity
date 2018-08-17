using System.Linq;

namespace Security.DataLayer
{
    public class RoomRepository
    {
        private SecurityDbContext _securityDbContext = new SecurityDbContext();

        public string GetRoomNameById(int roomId)
        {
            return _securityDbContext.Rooms.Single(room => room.Id == roomId).Name;
        }

        public int[] GetRoomsIdsbyMonitorId(int monitorId)
        {
            return _securityDbContext.Rooms.Where(room => room.MonitorId == monitorId)
                .Select(room => room.Id).ToArray();
        }
    }
}