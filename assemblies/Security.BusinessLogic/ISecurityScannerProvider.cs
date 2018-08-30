namespace Security.BusinessLogic
{
    public interface ISecurityScannerProvider
    {
        SecurityScanner GetRoomScanner(int roomId, IRecognizer recognizer);
    }
}