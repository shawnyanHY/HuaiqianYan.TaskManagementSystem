using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T: class
    {
        public Task<T> Create(T obj);

        public Task<T> Update(T obj);

        public Task<bool> Delete(T obj);

        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null);

        public Task<T> GetById(int? id);

        public Task<int> Count();
    }
}
