using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.PET.Models;

namespace App.PET.Database
{
    public class GoPetDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public GoPetDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(AppointmentModel).Name))
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(AppointmentModel)).ConfigureAwait(false);

                initialized = true;
            }
        }

        public Task<List<AppointmentModel>> GetAppointments()
        {
            return Database.Table<AppointmentModel>().ToListAsync();
        }

        public Task<int> SaveAppointment(AppointmentModel appointment)
        {
            if (appointment.Id == 0)
                return Database.InsertAsync(appointment);
            else
                return Database.UpdateAsync(appointment);
        }

        public Task<int> DeleteAppointment(AppointmentModel product)
        {
            return Database.DeleteAsync(product);
        }
    }
}