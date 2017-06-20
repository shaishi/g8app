﻿﻿using System;
using System.Collections.Generic;
using g8.Models;
using Xamarin.Forms;

namespace g8.Views
{
    public partial class DriverPage : ContentPage
    {
        public DriverPage(bool isRegister = false)
        {
            InitializeComponent();

        }

        public async void OnButtonClick(object sender, EventArgs e)
        {
            var ride = new Ride();

            ride.Destination = dest.Text;
            ride.Hour = when.Text;
            ride.Room = int.Parse(room.Text);
            Settings.AddedRow = ride;
            await Navigation.PopAsync(true);
        }
    }
}
