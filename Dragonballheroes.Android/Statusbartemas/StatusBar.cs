using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Dragonballheroes.Droid.Statusbartemas;
using Dragonballheroes.VistaModelo;
using Plugin.CurrentActivity;

[assembly: Dependency(typeof(StatusBar))]
namespace Dragonballheroes.Droid.Statusbartemas
{
    class StatusBar : VMstatusbar
    {
        public void Transparente()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var currectWindow = GetCurrentWindow();
                currectWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutFullscreen;
                currectWindow.SetStatusBarColor(Android.Graphics.Color.Transparent);
            });
        }
        Window GetCurrentWindow()
        {
            var window = CrossCurrentActivity.Current.Activity.Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            return window;
        }
    }
}