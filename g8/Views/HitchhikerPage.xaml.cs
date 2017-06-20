﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using g8.Models;
using g8.Services;
using Xamarin.Forms;

namespace g8.Views
{
    public partial class HitchhikerPage : ContentPage
    {
        public ObservableCollection<Ride> rides;
        public int lastSelectedRideIdx = -1;
        public HitchhikerPage()
        {
            rides = new ObservableCollection<Ride>();
            InitializeComponent();
            GetBus();
            GetRides();
        }

        public void GetBus()
        {
            var busRide = new Ride();
            busRide.Destination = "אוניברסיטה";
            busRide.Hour = "8 דקות";
            busRide.Room = 38;
            rides.Add(busRide);
        }

        public void GetRides()
        {
            SQLDataStore ds = new SQLDataStore();
            var dbRides = ds.GetRides();
            dbRides.Sort((x, y) => TimeSpan.Parse(y.Hour).CompareTo(TimeSpan.Parse(x.Hour)));
            dbRides.ForEach((ride) =>
            {
                rides.Add(ride);
            });
            UpdateList();
        }

        public void OnTap(object sender, EventArgs e)
        {

            var stl = sender as StackLayout;
            var ride = new Ride();
            Console.WriteLine(stl.Children.Count);
            ride.Destination = ((Label)stl.Children[2]).Text;
            ride.Hour = ((Label)stl.Children[1]).Text;
            ride.Room = int.Parse(((Label)stl.Children[0]).Text.Substring(15));
            for (int i = 0; i < rides.Count; i++)
            {
                if (rides[i].Equals(ride))
                {
                    if (lastSelectedRideIdx != -1)
                    {
                        rides[lastSelectedRideIdx].Room += 1;
                    }
                    lastSelectedRideIdx = i;
                    rides[i].Room -= 1;
                }
            }
            UpdateList();
        }

        public void UpdateList() 
        {
            mainGrid.Children.Clear();
            if (Settings.AddedRow != null)
            {
                rides.Add(Settings.AddedRow);
                Settings.AddedRow = null;
            }
			for (int i = 0; i < rides.Count; i++)
			{
				StackLayout stl = new StackLayout
				{
					BackgroundColor = new Color(255, 255, 255),
					Orientation = StackOrientation.Horizontal,
					HeightRequest = 50
				};
                if (i == lastSelectedRideIdx)
                {
                    stl.BackgroundColor = new Color(0, 116, 255); 
                }
				var ride = rides[i];
				TapGestureRecognizer tgr = new TapGestureRecognizer();
				tgr.Tapped += (sender, e) => OnTap(sender, e);
				mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
				
				stl.GestureRecognizers.Add(tgr);
				Grid.SetRow(stl, i);
				Grid.SetColumnSpan(stl, 3);
                Label lbl3 = new Label { Text = ride.Destination, FontSize = 16, WidthRequest = 130, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment=TextAlignment.End };
				Label lbl2 = new Label { Text = ride.Hour, FontSize = 16, WidthRequest = 100, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.End };
				Label lbl1 = new Label { Text = "מקומות פנויים: " + ride.Room, FontSize = 16, WidthRequest = 130, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.End };
				stl.Children.Add(lbl1);
				stl.Children.Add(lbl2);
				stl.Children.Add(lbl3);
				mainGrid.Children.Add(stl);
				Grid.SetRow(lbl1, i);
				Grid.SetRow(lbl2, i);
				Grid.SetRow(lbl3, i);
				Grid.SetColumn(lbl1, 0);
				Grid.SetColumn(lbl2, 1);
				Grid.SetColumn(lbl3, 2);
			}
        }
        //public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as Ride;
        //    if (item == null)
        //        return;

        //    if (lastSelectedRideIdx != -1)
        //    {
        //        rides[lastSelectedRideIdx].Room = rides[lastSelectedRideIdx].Room + 1;
        //    }
        //    lastSelectedRideIdx = rides.IndexOf(item);

        //    rides[lastSelectedRideIdx].Room = rides[lastSelectedRideIdx].Room - 1;
        //    // Manually deselect item
        //    ridesList.SelectedItem = null;
        //}
    }
}
