using RegistR.Attributes;
using RegistR.Attributes.Base;

namespace RegistR.UnitTests.Services;

public interface IDefaultServiceWithInterface
{
}

[Register<IDefaultServiceWithInterface>]
public class DefaultServiceWithInterface : IDefaultServiceWithInterface
{
}
