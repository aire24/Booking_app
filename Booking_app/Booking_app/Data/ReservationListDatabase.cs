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
            _database.CreateTableAsync<Client>().Wait();
            _database.CreateTableAsync<ListClient>().Wait();
        }
        public Task<int> SaveClientAsync(Client client)
        {
           if (client.ID != 0)
            {
                return _database.UpdateAsync(client);
            }
            else
            {
                return _database.InsertAsync(client);
            }
        }
        public Task<int> DeleteClientAsync(Client client)
        {
            return _database.DeleteAsync(client);
        }
        public Task<List<Client>> GetClientsAsync()
        {
            return _database.Table<Client>().ToListAsync();
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
        public Task<int> SaveListClientAsync(ListClient listc)
        {
            if (listc.ID != 0)
            {
                return _database.UpdateAsync(listc);
            }
            else
            {
                return _database.InsertAsync(listc);
            }
        }
        public Task<List<Client>> GetListClientsAsync(int reservationlistid)
        {
            return _database.QueryAsync<Client>(
            "select C.ID, C.Description from Client C"
            + " inner join ListClient LC"
            + " on C.ID = LC.ClientID where LC.ReservationListID = ?",
            reservationlistid);
        }
    }
}
