using SQLite.Net.Async;
using SQLiteDemo.Portable.Model.DataContext.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SQLiteDemo.Portable.Model.Repositories.Base
{
    public class BaseSQLiteRepository<T> : IRepository<T>
        where T : class, new()
    {
        protected SQLiteAsyncConnection Connection { get; set; }

        public BaseSQLiteRepository(ISQLiteDataContext dataContext)
        {
            Connection = dataContext.SQLiteAsyncConnection;
        }

        public Task InitializeAsync()
        {
            return Connection.CreateTableAsync<T>();
        }

        public async Task<T> CreateAsync(T value)
        {
            await Connection.InsertAsync(value);
            return value;
        }

        public Task<int> CreateAsync(IEnumerable values)
        {
            return Connection.InsertAllAsync(values);
        }

        public Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return Connection.Table<T>().Where(predicate).ToListAsync();
        }

        public Task<int> UpdateAsync(T value)
        {
            return Connection.UpdateAsync(value);
        }

        public Task<int> DeleteAsync(T value)
        {
            return Connection.DeleteAsync(value);
        }

        public async Task<int> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            List<T> objects = await FindAsync(predicate);
            foreach (T oneObject in objects)
            {
                await DeleteAsync(oneObject);
            }

            return objects.Count;
        }
    }
}

