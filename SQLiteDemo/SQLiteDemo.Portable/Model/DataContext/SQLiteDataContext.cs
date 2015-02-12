using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using SQLiteDemo.Portable.Model.DataContext.Base;

namespace SQLiteDemo.Portable.Model.DataContext
{
    public abstract class SQLiteDataContext : ISQLiteDataContext
    {
        protected string DatabaseName { get { return "test.db"; } }

        protected abstract ISQLitePlatform SQLitePlatform { get; }

        protected abstract SQLiteConnectionString ConnectionString { get; }

        public SQLiteAsyncConnection SQLiteAsyncConnection { get; private set; }

        public SQLiteDataContext()
        {
            SQLiteAsyncConnection = new SQLiteAsyncConnection(
                () => new SQLiteConnectionWithLock(SQLitePlatform, ConnectionString));
        }
    }
}
