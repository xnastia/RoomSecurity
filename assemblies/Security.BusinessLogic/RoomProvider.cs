using Security.DataLayer;

namespace Security.BusinessLogic
{
    public class RoomProvider
    {
        RoomRepository _roomRepository = new RoomRepository();

        public string GetRoomName(int roomId)
        {
            return _roomRepository.GetRoomNameById(roomId);
        }

        public int[] GetRoomsIdsByMonitorId(int monitorId)
        {
            return _roomRepository.GetRoomsIdsbyMonitorId(monitorId);
        }
    }
}