using Security.DataLayer;

namespace Security.BusinessLogic
{
    public class RoomProvider
    {
        RoomRepository _roomRepository = new RoomRepository();

        public string GetRoomName(int roomId)
        {
            return _roomRepository.GetRoomName(roomId);
        }
    }
}