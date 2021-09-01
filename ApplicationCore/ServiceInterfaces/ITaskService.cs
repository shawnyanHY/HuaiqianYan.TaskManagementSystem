using ApplicationCore.Models;
using TaskEntity = ApplicationCore.Entities.Task;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ITaskService
    {
        public Task<TaskEntity> AddTask(TaskRequestModel task);

        public Task<TaskEntity> UpdateTask(TaskUpdateRequestModel task);

        public Task<IEnumerable<TaskResponseModel>> GetTasks();

        public Task<TaskResponseModel> GetTaskById(int id);

        public Task<bool> DeleteTask(int id);

        public Task<bool> CompleteTask(int id);
    }
}
