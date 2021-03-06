using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Booking_app.Data;
using System.IO;

namespace Booking_app
{
    public partial class App : Application
    {
        static RoomListDatabase database1;
        public static RoomListDatabase Database1
        {
            get
            {
                if (database1 == null)
                {
                    database1 = new
                   RoomListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "RoomList.db3"));
                }
                return database1;
            }
        }

        static ReservationListDatabase database;
        public static ReservationListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ReservationListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ReservationList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ListEntryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
