using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking_app.Models
{
    public class RoomList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

    }
}
