using Microsoft.Extensions.DependencyInjection;
using RegistR.Attributes;
using RegistR.Attributes.Base;
using RegistR.Attributes.Extensions;
using System.Reflection;

namespace RegistR.Attributes.Extensions;

public static class RegisterAttributesExtensions
{
    public static void InstallRegisterAttribute(this IServiceCollection services, Assembly assembly) => services.RegisterAssembly(assembly);

    public static void InstallRegisterAttribute(this IServiceCollection services, Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            services.RegisterAssembly(assembly);
        }
    }

    private static void RegisterAssembly(this IServiceCollection services, Assembly assembly)
    {
        var classes = assembly.GetTypes().Where(t => t.GetCustomAttributes(typeof(RegisterAttribute), true).FirstOrDefault() != null).ToList();

        foreach (var @class in classes)
        {
            var attribute = @class.GetCustomAttribute<RegisterAttribute>();

            Type? @interface = attribute!.Interface;
            if (@interface == null)
                @interface = @class;

            services.Register(@interface, @class, attribute.Lifetime);
        }
    }

    private static void Register(this IServiceCollection services, Type @interface, Type type, ServiceLifetime lifeTime)
    {
        switch (lifeTime)
        {
            case ServiceLifetime.Singleton:
                services.AddSingleton(@interface, type);
                break;
            case ServiceLifetime.Scoped:
                services.AddScoped(@interface, type);
                break;
            case ServiceLifetime.Transient:
                services.AddTransient(@interface, type);
                break;
        }
    }
}
