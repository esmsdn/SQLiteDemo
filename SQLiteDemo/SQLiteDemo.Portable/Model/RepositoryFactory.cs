using SQLiteDemo.Portable.Model.DataContext;
using SQLiteDemo.Portable.Model.DataContext.Base;
using SQLiteDemo.Portable.Model.Repositories;

namespace SQLiteDemo.Portable.Model
{
    public class RepositoryFactory
    {
        private ISQLiteDataContext DataContext { get; set; }

        public RepositoryFactory(SQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public PersonRepository Persons
        {
            get
            {
                var repository = new PersonRepository(DataContext);
                repository.InitializeAsync().Wait();
                return repository;
            }
        }
    }
}
