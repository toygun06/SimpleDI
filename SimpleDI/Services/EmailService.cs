namespace SimpleDI.Services
{
    /// IMessageService'in e-posta ile gerçekleştiren implementasyonu.

    public class EmailService : IMessageService
    {
        public void Send(string message)
        {
            Console.WriteLine($"[EmailService] {message}");
        }
    }
}
