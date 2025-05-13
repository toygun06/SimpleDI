using System.Reflection;

namespace SimpleDI.DI
{
    /// Uygulamanın servis kayıtlarını tutar ve çözümleme yapar.

    public class Container
    {
        protected readonly Dictionary<Type, ServiceDescriptor> _services = new();

        /// Bir arayüz ve implementasyonunu belirli bir yaşam döngüsüyle kaydeder.

        public void Register<TService, TImplementation>(Lifetime lifetime)
            where TImplementation : TService
        {
            _services[typeof(TService)] = new ServiceDescriptor(typeof(TService), typeof(TImplementation), lifetime);
        }

        /// Arayüzsüz sınıflar için kolay kayıt metodu.

        public void Register<TService>(Lifetime lifetime)
            => Register<TService, TService>(lifetime);

        /// Servisi çözümle (yalnızca Singleton ve Transient için).

        public virtual object Resolve(Type serviceType)
        {
            if (!_services.TryGetValue(serviceType, out var descriptor))
                throw new Exception($"Service {serviceType.Name} not registered");

            if (descriptor.Lifetime == Lifetime.Singleton)
            {
                if (descriptor.ImplementationInstance == null)
                    descriptor.ImplementationInstance = CreateInstance(descriptor.ImplementationType);
                return descriptor.ImplementationInstance;
            }

            if (descriptor.Lifetime == Lifetime.Transient)
                return CreateInstance(descriptor.ImplementationType);

            throw new Exception("Scoped çözümleri için ScopedContainer kullanılmalı.");
        }

        public T Resolve<T>() => (T)Resolve(typeof(T));

        public ScopedContainer CreateScope() => new ScopedContainer(this);

        protected internal Dictionary<Type, ServiceDescriptor> GetServices() => _services;

        /// Constructor parametrelerini reflection ile çözümleyerek örnek oluşturur.

        protected virtual object CreateInstance(Type implementationType)
        {
            var constructor = implementationType.GetConstructors().First();
            var parameters = constructor.GetParameters();

            if (parameters.Length == 0)
                return Activator.CreateInstance(implementationType)!;

            var dependencies = parameters
                .Select(p => this.Resolve(p.ParameterType)) // this.Resolve çok önemli
                .ToArray();

            return constructor.Invoke(dependencies);
        }
    }
}
