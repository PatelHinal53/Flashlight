using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Xamarin.Essentials;

namespace FlashlightDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class FlashlightActivity : AppCompatActivity
    {
        private Button _turnOnbutton;
        private Button _turnOffbutton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            UIReference();
            UIClickEvents();
        }

        private void UIReference()
        {
            _turnOnbutton = FindViewById<Button>(Resource.Id.turnOn);
            _turnOffbutton = FindViewById<Button>(Resource.Id.turnOff);
        }

        private void UIClickEvents()
        {
            _turnOnbutton.Click += TurnOnbutton_Click;
            _turnOffbutton.Click += TurnOffbutton_Click;
        }

        private async void TurnOffbutton_Click(object sender, EventArgs e)
        {
            try
            {
                await Flashlight.TurnOffAsync();
            }
            catch (FeatureNotSupportedException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private async void TurnOnbutton_Click(object sender, EventArgs e)
        {
            try
            {
                await Flashlight.TurnOnAsync();
            }
            catch (FeatureNotSupportedException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}