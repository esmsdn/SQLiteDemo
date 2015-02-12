using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.WindowsPhone8;
using SQLiteDemo.Portable.Model.DataContext;
using System.IO;
using Windows.Storage;

namespace SQLiteDemo.XamarinForms.WinPhone.DataContext
{
    public class SQLiteDataContextWP8 : SQLiteDataContext
    {
        protected override ISQLitePlatform SQLitePlatform
        {
            get
            {
                return new SQLitePlatformWP8();
            }
        }

        protected override SQLiteConnectionString ConnectionString
        {
            get
            {
                return new SQLiteConnectionString(Path.Combine(ApplicationData.Current.LocalFolder.Path, DatabaseName), false);
            }
        }
    }
}
