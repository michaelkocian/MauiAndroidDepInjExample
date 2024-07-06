using System;

namespace MauiAndroidDepInjExample.Droid.Services;
internal class MySingletonService : IDisposable
{
    public MySingletonService()
    {
        Console.WriteLine("Singleton Service created.");
    }

    public void Dispose()
    {
        Console.WriteLine("Singleton Service disposed.");
    }

    public void Run()
    {
        Console.WriteLine("Singleton Service executed.");
    }
}
