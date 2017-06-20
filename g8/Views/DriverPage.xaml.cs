using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace g8.Views
{
    public partial class DriverPage : ContentPage
    {
        public DriverPage()
        {
            InitializeComponent();
        }

        public async void OnButtonClick(object sender, EventArgs e)
        {
            await Navigation.PopAsync(true);
        }
    }
}
