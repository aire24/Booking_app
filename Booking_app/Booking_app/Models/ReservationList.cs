using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking_app.Models
{
    public class ReservationList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
