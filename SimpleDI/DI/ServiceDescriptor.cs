namespace SimpleDI.DI
{
    /// Servis hakkında bilgi tutar: türü, implementasyonu ve yaşam döngüsü.

    public class ServiceDescriptor
    {
        public Type ServiceType { get; }
        public Type ImplementationType { get; }
        public Lifetime Lifetime { get; }
        public object? ImplementationInstance { get; set; } // Singleton için cache

        public ServiceDescriptor(Type serviceType, Type implementationType, Lifetime lifetime)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
            Lifetime = lifetime;
        }
    }
}
