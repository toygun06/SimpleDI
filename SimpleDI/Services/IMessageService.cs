namespace SimpleDI.Services
{

    /// Bildirim gönderme arayüzü.

    public interface IMessageService
    {
        void Send(string message);
    }
}
