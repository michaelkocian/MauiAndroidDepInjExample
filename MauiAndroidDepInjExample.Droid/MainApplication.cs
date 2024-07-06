using Android.App;
using Android.OS;
using Android.Runtime;
using MauiAndroidDepInjExample.Droid.Extensions;
using MauiAndroidDepInjExample.Droid.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using static Android.App.Application;

namespace MauiAndroidDepInjExample.Droid;

[Application]
public class MainApplication : Application, IActivityLifecycleCallbacks
{
    public ServiceProvider ServiceProvider { get; private set; } = null!;
    private readonly Dictionary<Activity, IServiceScope> _scopes = [];

    private ServiceProvider BuildServices()
    {
        ServiceCollection services = new();

        services.AddSingleton<MySingletonService>();
        services.AddScoped<MyScopedService>();
        services.AddTransient<MyTransientService>();

        return services.BuildServiceProvider();
    }

    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    public override void OnCreate()
    {
        base.OnCreate();
        ServiceProvider = BuildServices();
        RegisterActivityLifecycleCallbacks(this);
    }

    public override void OnTerminate()
    {
        ServiceProvider.Dispose();
        base.OnTerminate();
        UnregisterActivityLifecycleCallbacks(this);
    }


    public void OnActivityStopped(Activity activity)
    {
        if (_scopes.Remove(activity, out IServiceScope? scope))
        {
            scope.Dispose();
        }
    }

    public void OnActivityCreated(Activity activity, Bundle? savedInstanceState)
    {
        var scope = ServiceProvider.CreateScope();
        _scopes.Add(activity, scope);
        activity.BindServices(scope);
    }

    public void OnActivityStarted(Activity activity) { }
    public void OnActivityDestroyed(Activity activity) { }
    public void OnActivityPaused(Activity activity) { }
    public void OnActivityResumed(Activity activity) { }
    public void OnActivitySaveInstanceState(Activity activity, Bundle outState) { }
}
