﻿using System.Collections.Generic;
using g8.Views;
using Xamarin.Forms;

namespace g8
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public static IDictionary<string, string> LoginParameters => null;

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();
            Settings.UserId = "";
            SetMainPage();
        }

        public static void SetMainPage()
        {
            
            if (!Settings.IsLoggedIn)
            {
                Current.MainPage = new NavigationPage(new Login())
                {
                    BarBackgroundColor = (Color)Current.Resources["Primary"],
                    BarTextColor = Color.White
                };
            }
            else
            {
                GoToMainPage();
            }
        }

        public static void GoToMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children = {
                    new NavigationPage(new Home())
                    {
                        Title = "Home",
                        Icon = "tab_feed.png"
                    },

                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = "tab_about.png"
                    },

                }

            };
        }
    }
}
