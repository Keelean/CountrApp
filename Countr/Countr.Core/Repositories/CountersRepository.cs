using Countr.Core.Models;
using PCLStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Countr.Core.Repositories
{
    public class CountersRepository: ICounterRepository
    {
        readonly SQLiteAsyncConnection connection;

        public CountersRepository()
        {
            var local = FileSystem.Current.LocalStorage.Path;
            var datafile = PortablePath.Combine(local, "counters.db3");
            connection = new SQLiteAsyncConnection(datafile);
            connection.GetConnection().CreateTable<Counter>();
        }

        public Task Delete(Counter counter)
        {
            return connection.DeleteAsync(counter);
        }

        public Task<List<Counter>> GetAll()
        {
            return connection.Table<Counter>().ToListAsync();
        }

        public Task Save(Counter counter)
        {
            return connection.InsertOrReplaceAsync(counter);
        }
    }
}
