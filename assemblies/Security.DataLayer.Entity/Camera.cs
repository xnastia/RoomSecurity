﻿namespace Security.DataLayer.Entity
{
    public class Camera
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}