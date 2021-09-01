using ApplicationCore.Entities;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ITaskHistoryService
    {
        public Task<TaskHistory> AddTaskHistory(TaskHistoryRequestModel task);

        public Task<TaskHistory> UpdateTaskHistory(TaskHistoryUpdateRequestModel task);

        public Task<IEnumerable<TaskHistoryResponseModel>> GetTaskHistory();

        public Task<TaskHistoryResponseModel> GetTaskHistoryById(int id);

        public Task<bool> DeleteTaskHistory(int id);
    }
}
