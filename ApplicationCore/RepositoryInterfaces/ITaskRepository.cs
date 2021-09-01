using TaskEntity = ApplicationCore.Entities.Task;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface ITaskRepository : IAsyncRepository<TaskEntity>
    {
    }
}
