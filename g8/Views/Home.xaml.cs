    ﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace g8.Views
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        async void OnDriverNav(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        async void OnHitchNav(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HitchhikerPage());
        }
    }
}
