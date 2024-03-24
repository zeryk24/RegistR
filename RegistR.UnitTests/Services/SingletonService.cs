using Microsoft.Extensions.DependencyInjection;
using RegistR.Attributes;
using RegistR.Attributes.Base;

namespace RegistR.UnitTests.Services;

[Register(ServiceLifetime.Singleton)]
public class SingletonService
{
}
