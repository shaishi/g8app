using System;
using System.Collections.Generic;
using g8.Models;

namespace g8.Services
{
    public class SQLDataStore
    {
        string rides = "SELECT * FROM dbo.trempim";
        string cs = "Server=tcp:g8-db.database.windows.net,1433;Initial Catalog=g8-db;Persist Security Info=False;User ID=g8admin;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public SQLDataStore()
        {
        }

        public List<Ride> GetRides()
        {
            Ride ride1 = new Ride { Hour = "17:54", Room = 3, Destination = "ראשון לציון" };
            Ride ride2 = new Ride { Hour = "18:10", Room = 2, Destination = "רעננה" };
            Ride ride3 = new Ride { Hour = "18:15", Room = 4, Destination = "נתניה" };
            return new List<Ride> { ride1, ride2, ride3 };

        }
    }
}
