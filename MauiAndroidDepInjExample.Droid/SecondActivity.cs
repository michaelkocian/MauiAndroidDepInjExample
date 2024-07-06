using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.AppCompat.App;
using MauiAndroidDepInjExample.Droid.Attributes;
using MauiAndroidDepInjExample.Droid.Services;

namespace MauiAndroidDepInjExample.Droid;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class SecondActivity : AppCompatActivity
{
    [BindService] MyScopedService _myScopedService = null!;
    [BindService] MySingletonService _mySingletonService = null!;
    [BindService] MyTransientService _myTransientService = null!;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_layout);

        _mySingletonService.Run();
        _myScopedService.Run();
        _myTransientService.Run();
    }

    public override void OnBackPressed()
    {
        Finish();
    }
}