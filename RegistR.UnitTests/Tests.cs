using Microsoft.Extensions.DependencyInjection;
using RegistR.Attributes.Extensions;
using RegistR.UnitTests.Services;
using System.Reflection;

namespace RegistR.UnitTests;

public class Tests
{
    [Theory]
    [InlineData(typeof(DefaultService), ServiceLifetime.Scoped)]
    [InlineData(typeof(IDefaultServiceWithInterface), ServiceLifetime.Scoped)]
    [InlineData(typeof(SingletonService), ServiceLifetime.Singleton)]
    [InlineData(typeof(ISingletonServiceWithInterface), ServiceLifetime.Singleton)]
    [InlineData(typeof(TransientService), ServiceLifetime.Transient)]
    [InlineData(typeof(ITransientServiceWithInterface), ServiceLifetime.Transient)]
    public void Register_DefaultService_Success(Type s, ServiceLifetime lifetime)
    {
        // Arrange
        var serviceCollection = new ServiceCollection();

        // Act
        serviceCollection.InstallRegisterAttribute(Assembly.GetExecutingAssembly());
        
        var serviceDescriptor = serviceCollection.Where(descriptor => descriptor.ServiceType == s).Single();
        var service = serviceCollection.BuildServiceProvider().GetService(s);

        // Assert
        Assert.NotNull(service);
        Assert.Equal(lifetime, serviceDescriptor.Lifetime);
    }
}