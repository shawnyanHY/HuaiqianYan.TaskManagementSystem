using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface ITaskHistoryRepository : IAsyncRepository<TaskHistory>
    {
        public Task<IEnumerable<TaskHistory>> GetRecent();
    }
}
