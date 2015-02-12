using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using SQLiteDemo.Portable.Model.DataContext;
using System.IO;
using Xamarin.Forms;

namespace SQLiteDemo.XamarinForms.Droid.DataContext
{
    public class SQLiteDataContextAndroid : SQLiteDataContext
    {
        protected override ISQLitePlatform SQLitePlatform
        {
            get
            {
                return new SQLitePlatformAndroid();
            }
        }

        protected override SQLiteConnectionString ConnectionString
        {
            get
            {
                return new SQLiteConnectionString(
                    Path.Combine(Forms.Context.ApplicationContext.FilesDir.AbsolutePath, DatabaseName), false);
            }
        }
    }
}
