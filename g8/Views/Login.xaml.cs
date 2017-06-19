using System;
using System.Collections.Generic;
using Plugin.Geolocator;

using Xamarin.Forms;

namespace g8.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            //GetLocation();
        }

        //public async void GetLocation()
        //{

        //    var locator = CrossGeolocator.Current;
        //    try
        //    {
        //        var position = await locator.GetPositionAsync(timeoutMilliseconds: 20000);
        //        MyLabel.Text = position.Latitude + " " + position.Longitude;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //}

        public void SignIn(object sender, EventArgs e)
        {
            Settings.UserId = "ShohamHaMeleh";
            App.GoToMainPage();
        }


    }
}
