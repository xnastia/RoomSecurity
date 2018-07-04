namespace Security.Entities
{
    public class Camera
    {
        public int Id { get; }

        public Camera(int cameraId)
        {
            Id = cameraId;
        }
        public byte[] GetImage()
        {
            return null;
        }
    }
}