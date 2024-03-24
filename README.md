# RegistR

## Overview
This NuGet package simplifies the process of registering dependencies in .NET applications using attributes. By leveraging attributes, developers can easily specify the services they want to register with the Dependency Injection (DI) container without writing extensive configuration code.

## Usage
1. Install the NuGet package in your project.
2. Call the `InstallRegisterAttribute` method during DI setup, passing the assembly containing the classes with registration attributes.

```csharp
builder.Services.InstallRegisterAttribute(assembly);
```

3. Annotate your service classes with registration attributes to indicate their registration behavior.
   
## Examples
### Scoped without interface
```csharp
[Register]
public class YourService
{
    // Implementation
}
```
### Scoped with interface
```csharp
[Register<IYourService>]
public class YourService : IYourService
{
    // Implementation
}
```
### Transient without interface
```csharp
[Register(ServiceLifetime.Transient)]
public class YourService
{
    // Implementation
}
```
### Transient with interface
```csharp
[Register<IYourService>(ServiceLifetime.Transient)]
public class YourService : IYourService
{
    // Implementation
}
```
### Singleton without interface
```csharp
[Register(ServiceLifetime.Singleton)]
public class YourService
{
    // Implementation
}
```
### Singleton with interface
```csharp
[Register<IYourService>(ServiceLifetime.Singleton)]
public class YourService : IYourService
{
    // Implementation
}
```
