using Microsoft.Extensions.DependencyInjection;
using RegistR.Attributes;

using RegistR.Attributes.Base;
namespace RegistR.UnitTests.Services;

public interface ITransientServiceWithInterface { }

[Register<ITransientServiceWithInterface>(ServiceLifetime.Transient)]
public class TransientServiceWithInterface : ITransientServiceWithInterface
{
}
