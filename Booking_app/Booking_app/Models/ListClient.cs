using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking_app.Models
{
    public class ListClient
    {
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            [ForeignKey(typeof(ReservationList))]
            public int ReservationListID { get; set; }
            public int ClientID { get; set; }
    }
}
