using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Models;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class TaskHistoryService : ITaskHistoryService
    {
        private readonly ITaskHistoryRepository _taskHistoryRepository;

        public TaskHistoryService(ITaskHistoryRepository taskHistoryRepository)
        {
            _taskHistoryRepository = taskHistoryRepository;
        }

        public async Task<TaskHistory> AddTaskHistory(TaskHistoryRequestModel taskHistoryRequestModel)
        {
            var taskHistory = new TaskHistory
            {
                UserId = taskHistoryRequestModel.UserId,
                Title = taskHistoryRequestModel.Title,
                Description = taskHistoryRequestModel.Description,
                DueDate = taskHistoryRequestModel.DueDate,
                Completed = taskHistoryRequestModel.Completed,
                Remarks = taskHistoryRequestModel.Remarks
            };

            return await _taskHistoryRepository.Create(taskHistory);
        }

        public async Task<TaskHistory> UpdateTaskHistory(TaskHistoryUpdateRequestModel taskHistoryUpdateRequestModel)
        {
            var taskHistory = await _taskHistoryRepository.GetById(taskHistoryUpdateRequestModel.TaskId);

            taskHistory.TaskId = taskHistoryUpdateRequestModel.TaskId;
            taskHistory.UserId = taskHistoryUpdateRequestModel.UserId;
            taskHistory.Title = taskHistoryUpdateRequestModel.Title;
            taskHistory.Description = taskHistoryUpdateRequestModel.Description;
            taskHistory.DueDate = taskHistoryUpdateRequestModel.DueDate;
            taskHistory.Completed = taskHistoryUpdateRequestModel.Completed;
            taskHistory.Remarks = taskHistoryUpdateRequestModel.Remarks;

            return await _taskHistoryRepository.Update(taskHistory);
        }

        public async Task<bool> DeleteTaskHistory(int id)
        {
            var taskHistory = await _taskHistoryRepository.GetById(id);
            if (taskHistory == null) return false;
            return await _taskHistoryRepository.Delete(taskHistory);
        }

        public async Task<IEnumerable<TaskHistoryResponseModel>> GetTaskHistory()
        {
            var taskHistroies = await _taskHistoryRepository.GetAll();
            var taskHistoryResponseModels = new List<TaskHistoryResponseModel>();
            foreach (var taskHistory in taskHistroies)
            {
                taskHistoryResponseModels.Add(new TaskHistoryResponseModel
                {
                    TaskId = taskHistory.TaskId,
                    UserId = taskHistory.UserId,
                    Title = taskHistory.Title,
                    Description = taskHistory.Description,
                    DueDate = taskHistory.DueDate,
                    Completed = taskHistory.Completed,
                    Remarks = taskHistory.Remarks
                });
            }
            return taskHistoryResponseModels;
        }

        public async Task<TaskHistoryResponseModel> GetTaskHistoryById(int id)
        {
            var taskHistory = await _taskHistoryRepository.GetById(id);
            if (taskHistory == null)
            {
                return null;
            }
            var taskHistoryResponseModel = new TaskHistoryResponseModel
            {
                TaskId = taskHistory.TaskId,
                UserId = taskHistory.UserId,
                Title = taskHistory.Title,
                Description = taskHistory.Description,
                DueDate = taskHistory.DueDate,
                Completed = taskHistory.Completed,
                Remarks = taskHistory.Remarks
            };

            return taskHistoryResponseModel;
        }
    }
}
