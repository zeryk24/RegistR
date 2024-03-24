using Microsoft.Extensions.DependencyInjection;
using RegistR.Attributes;
using RegistR.Attributes.Base;

namespace RegistR.UnitTests.Services;

public interface ISingletonServiceWithInterface { }

[Register<ISingletonServiceWithInterface>(ServiceLifetime.Singleton)]
public class SingletonServiceWithInterface : ISingletonServiceWithInterface
{
}
