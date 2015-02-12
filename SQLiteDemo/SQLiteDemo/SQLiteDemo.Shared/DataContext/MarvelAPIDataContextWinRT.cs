using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.WinRT;
using SQLiteDemo.Portable.Model.DataContext;
using System.IO;
using Windows.Storage;

namespace MarvelApp.DataContext
{
    public class SQLiteDataContextWinRT : SQLiteDataContext
    {
        protected override ISQLitePlatform SQLitePlatform
        {
            get
            {
                return new SQLitePlatformWinRT();
            }
        }

        protected override SQLiteConnectionString ConnectionString
        {
            get
            {
                return new SQLiteConnectionString(
                    Path.Combine(ApplicationData.Current.LocalFolder.Path, DatabaseName), false);
            }
        }
    }
}
