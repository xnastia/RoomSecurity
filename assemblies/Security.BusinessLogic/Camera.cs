namespace Security.BusinessLogic
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