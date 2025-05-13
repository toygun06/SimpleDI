namespace SimpleDI.DI
{
    /// Scoped yaşam döngüsüne sahip nesneleri yönetir.
    /// 
    public class ScopedContainer : Container
    {
        private readonly Container _root;
        private readonly Dictionary<Type, object> _scopedInstances = new();

        public ScopedContainer(Container root)
        {
            _root = root;
        }

        public override object Resolve(Type serviceType)
        {
            var registration = _root.GetServices()[serviceType];

            if (registration.Lifetime == Lifetime.Singleton)
                return _root.Resolve(serviceType);

            if (registration.Lifetime == Lifetime.Scoped)
            {
                if (!_scopedInstances.ContainsKey(serviceType))
                {
                    var instance = CreateInstance(registration.ImplementationType); // Artık override'ı çağıracak
                    _scopedInstances[serviceType] = instance;
                }

                return _scopedInstances[serviceType];
            }

            return CreateInstance(registration.ImplementationType);
        }

        // override önemli
        protected override object CreateInstance(Type implementationType)
        {
            var constructor = implementationType.GetConstructors().First();
            var parameters = constructor.GetParameters();

            if (parameters.Length == 0)
                return Activator.CreateInstance(implementationType)!;

            var dependencies = parameters
                .Select(p => Resolve(p.ParameterType)) // ScopedContainer.Resolve çağrılır
                .ToArray();

            return constructor.Invoke(dependencies);
        }
    }
}
