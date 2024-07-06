using System;

namespace MauiAndroidDepInjExample.Droid.Services;
internal class MyTransientService : IDisposable
{
    private readonly MyScopedService _myScopedService;
    private readonly MySingletonService _mySingletonService;

    public MyTransientService(MyScopedService myScopedService, MySingletonService mySingletonService)
    {
        Console.WriteLine("Transient Service created.");
        _myScopedService = myScopedService;
        _mySingletonService = mySingletonService;
    }

    public void Dispose()
    {
        Console.WriteLine("Transient Service disposed.");
    }

    public void Run()
    {
        Console.WriteLine("Transient Service executed.");
        _myScopedService.Run();
        _mySingletonService.Run();
    }
}
