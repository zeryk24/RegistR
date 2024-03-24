using Microsoft.Extensions.DependencyInjection;
using RegistR.Attributes;
using RegistR.Attributes.Base;

namespace RegistR.UnitTests.Services;

[Register(ServiceLifetime.Transient)]
public class TransientService
{
}
