using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Booking_app.Models;

namespace Booking_app.Data
{
    public class ReservationListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ReservationListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ReservationList>().Wait();
        }
        public Task<List<ReservationList>> GetReservationListsAsync()
        {
            return _database.Table<ReservationList>().ToListAsync();
        }
        public Task<ReservationList> GetReservationListAsync(int id)
        {
            return _database.Table<ReservationList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveReservationListAsync(ReservationList rlist)
        {
            if (rlist.ID != 0)
            {
                return _database.UpdateAsync(rlist);
            }
            else
            {
                return _database.InsertAsync(rlist);
            }
        }
        public Task<int> DeleteReservationListAsync(ReservationList rlist)
        {
            return _database.DeleteAsync(rlist);
        }
    }
}
