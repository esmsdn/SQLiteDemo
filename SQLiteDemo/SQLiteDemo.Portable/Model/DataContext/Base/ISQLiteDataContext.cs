using SQLite.Net.Async;

namespace SQLiteDemo.Portable.Model.DataContext.Base
{
    public interface ISQLiteDataContext
    {
        SQLiteAsyncConnection SQLiteAsyncConnection { get; }
    }
}
