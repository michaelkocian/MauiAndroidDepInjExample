using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.AppCompat.App;
using Java.Security;
using MauiAndroidDepInjExample.Droid.Attributes;
using MauiAndroidDepInjExample.Droid.Services;

namespace MauiAndroidDepInjExample.Droid;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : AppCompatActivity
{
    [BindService] private MySingletonService _mySingletonService = null!;
    [BindService] private MyScopedService _myScopedService = null!;
    [BindService] private MyTransientService _myTransientService = null!;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_layout);

        _mySingletonService.Run();
        _myScopedService.Run();
        _myTransientService.Run();

        Task.Run(async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            RunOnUiThread(() =>
            {
                StartActivity(typeof(SecondActivity));
            });
        });
    }

    public override void OnBackPressed()
    {
        Finish();
    }
}