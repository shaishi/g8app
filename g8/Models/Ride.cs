using System;
namespace g8.Models
{
    public class Ride : ObservableObject
    {
        public Ride()
        {
        }

        string destination = string.Empty;
        public string Destination
        {
            get { return this.destination; }
            set { SetProperty(ref destination, value); }
        }

        string hour = string.Empty;
        public string Hour
        {
            get { return this.hour; }
            set { SetProperty(ref hour, value); }
        }

        int room = 0;
        public int Room
        {
            get { return this.room; }
            set { SetProperty(ref room, value); }
        }

        public override bool Equals(object obj)
        {

            var ride = obj as Ride;
            if (ride != null)
            {
                return this.Room == ride.Room && this.Hour == ride.Hour && this.Destination == ride.Destination;
            }
            return false;


        }
    }
}
