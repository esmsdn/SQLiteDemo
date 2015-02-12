using SQLiteDemo.Portable.Model;
using SQLiteDemo.Portable.ViewModel;
#if WINDOWS_PHONE
using SQLiteDemo.XamarinForms.WinPhone.DataContext;
#elif ANDROID
using SQLiteDemo.XamarinForms.Droid.DataContext;
#endif
using Xamarin.Forms;

namespace SQLiteDemo.XamarinForms
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();

#if WINDOWS_PHONE
            BindingContext = new MainViewModel(new RepositoryFactory(new SQLiteDataContextWP8()));
#elif ANDROID
            BindingContext = new MainViewModel(new RepositoryFactory(new SQLiteDataContextAndroid()));
#endif
        }
	}
}
