namespace SimpleDI.Services
{
    /// IMessageService ve Logger bağımlılıklarıyla çalışan bildirim sınıfı.
    public class Notifier
    {
        private readonly IMessageService _messageService;
        private readonly Logger _logger;

        public Notifier(IMessageService messageService, Logger logger)
        {
            _messageService = messageService;
            _logger = logger;
        }

        public void Notify(string text)
        {
            _logger.Log("Gönderim başlatılıyor...");
            _messageService.Send(text);
        }
    }
}
