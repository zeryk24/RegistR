using Microsoft.Extensions.DependencyInjection;

namespace RegistR.Attributes.Base;

[AttributeUsage(AttributeTargets.Class)]
public class RegisterAttribute<TType> : RegisterAttribute
{
    public RegisterAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped) : base(lifetime, typeof(TType)) { }
}

[AttributeUsage(AttributeTargets.Class)]
public class RegisterAttribute : Attribute
{
    public Type? Interface { get; }
    public ServiceLifetime Lifetime { get; }

    public RegisterAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped, Type? @interface = null)
    {
        Lifetime = lifetime;
        Interface = @interface;
    }
}

