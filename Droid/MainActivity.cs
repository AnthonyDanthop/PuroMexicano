﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ImageCircle.Forms.Plugin.Droid;
using Android.OS;
using Plugin.Permissions;
using Acr.UserDialogs;

namespace PuroMexicano.Droid
{
    [Activity(Label = "PuroMexicano.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            UserDialogs.Init(this);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            ImageCircleRenderer.Init();
			Rg.Plugins.Popup.Popup.Init(this, bundle);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
