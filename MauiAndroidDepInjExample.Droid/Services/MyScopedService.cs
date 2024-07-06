using System;

namespace MauiAndroidDepInjExample.Droid.Services;
internal class MyScopedService : IDisposable
{
    private readonly MySingletonService _mySingletonService;

    public MyScopedService(MySingletonService mySingletonService)
    {
        Console.WriteLine("Scoped Service created.");
        _mySingletonService = mySingletonService;
    }

    public void Dispose()
    {
        Console.WriteLine("Scoped Service disposed.");
    }

    public void Run()
    {
        Console.WriteLine("Scoped Service executed.");
        _mySingletonService.Run();
    }
}
