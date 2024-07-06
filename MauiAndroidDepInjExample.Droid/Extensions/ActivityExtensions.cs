using System;
using System.Reflection;
using Android.App;
using MauiAndroidDepInjExample.Droid.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace MauiAndroidDepInjExample.Droid.Extensions;
public static class ActivityExtensions
{
    public static void BindServices(this Activity activity, IServiceScope scope)
    {
        var fields = activity.GetType().GetFields(BindingFlags.Public
                           | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var field in fields)
        {
            var attribute = field.GetCustomAttribute<BindServiceAttribute>();
            if (attribute != null)
            {
                Type type = field.FieldType;
                var service = scope.ServiceProvider.GetRequiredService(type);
                field.SetValue(activity, service);
            }
        }
    }
}