using SQLiteDemo.Portable.Model.DataContext.Base;
using SQLiteDemo.Portable.Model.Entities;
using SQLiteDemo.Portable.Model.Repositories.Base;

namespace SQLiteDemo.Portable.Model.Repositories
{
    public class PersonRepository : BaseSQLiteRepository<Person>
    {
        public PersonRepository(ISQLiteDataContext dataContext)
            : base(dataContext)
        {
        }
    }
}
