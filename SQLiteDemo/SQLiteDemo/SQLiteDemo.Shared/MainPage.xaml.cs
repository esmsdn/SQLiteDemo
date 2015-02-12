using MarvelApp.DataContext;
using SQLiteDemo.Portable.Model;
using SQLiteDemo.Portable.ViewModel;
using Windows.UI.Xaml.Controls;

namespace SQLiteDemo
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            DataContext = new MainViewModel(new RepositoryFactory(new SQLiteDataContextWinRT()));
        }
    }
}
