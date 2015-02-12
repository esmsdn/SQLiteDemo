using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SQLiteDemo.Portable.Model.Repositories.Base
{
    public interface IRepository<T>
        where T : class, new()
    {
        Task<T> CreateAsync(T value);

        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task<int> UpdateAsync(T value);

        Task<int> DeleteAsync(T value);
    }
}