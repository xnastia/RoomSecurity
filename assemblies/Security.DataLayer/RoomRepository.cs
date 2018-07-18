using System;
using System.Linq;

namespace Security.DataLayer
{
    public class RoomRepository
    {
        private SecurityDbContext _securityDbContext = new SecurityDbContext();

        public string GetRoomName(int roomId)
        {
            //return _securityDbContext.Rooms.Single(x => x.Id == roomId).Name;

            switch (roomId)
            {
                case 1:
                    return "Conference room";
                case 2:
                    return "Hall";
                case 3:
                    return "Dinner room";
                case 4:
                    return "Armory room";
                default:
                    throw new NotImplementedException(
                        "1 to 4 Ids are valid for now before DataLayer and DB has been implemented");
            }
        }
    }
}