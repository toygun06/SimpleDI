namespace SimpleDI.DI
{
    /// Servisin yaşam döngüsünü tanımlar: Singleton, Scoped ya da Transient.

    public enum Lifetime
    {
        Transient,
        Singleton,
        Scoped
    }
}
