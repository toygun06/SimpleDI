using SimpleDI.DI;
using SimpleDI.Services;

class Program
{
    static void Main(string[] args)
    {
        // DI konteyner oluşturuluyor
        var container = new Container();

        // Servislerin kaydı yapılıyor
        container.Register<IMessageService, EmailService>(Lifetime.Singleton);
        container.Register<Logger>(Lifetime.Scoped);
        container.Register<Notifier>(Lifetime.Transient);

        // Scope oluşturuluyor
        var scope = container.CreateScope();

        // Servis çözümlemesi ve kullanım
        var notifier = scope.Resolve<Notifier>();
        notifier.Notify("SimpleDI başarıyla çalıştı!");
    }
}