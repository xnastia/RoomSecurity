using System.Linq;

namespace Security.DataLayer
{
    public class RoomRepository
    {
        private SecurityDbContext _securityDbContext = new SecurityDbContext();

        public string GetRoomNameById(int roomId)
        {
            return _securityDbContext.Rooms.Single(x => x.Id == roomId).Name;

        }
    }
}