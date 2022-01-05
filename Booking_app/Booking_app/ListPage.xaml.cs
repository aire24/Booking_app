using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking_app.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Booking_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var rlist = (ReservationList)BindingContext;
            rlist.Date = DateTime.UtcNow;
            await App.Database.SaveReservationListAsync(rlist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var rlist = (ReservationList)BindingContext;
            await App.Database.DeleteReservationListAsync(rlist);
            await Navigation.PopAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var reservationl = (ReservationList)BindingContext;

            listView.ItemsSource = await App.Database.GetListClientsAsync(reservationl.ID);
        }
    }
}