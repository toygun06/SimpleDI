namespace SimpleDI.Services
{
    /// Basit bir loglama sınıfı.

    public class Logger
    {
        public void Log(string msg)
        {
            Console.WriteLine($"[Logger] {msg}");
        }
    }
}
