using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using TaskEntity = ApplicationCore.Entities.Task;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskHistoryRepository _taskHistoryRepository;

        public TaskService(ITaskRepository taskRepository, ITaskHistoryRepository taskHistoryRepository)
        {
            _taskRepository = taskRepository;
            _taskHistoryRepository = taskHistoryRepository;
        }

        public async Task<TaskEntity> AddTask(TaskRequestModel taskRequestModel)
        {
            var task = new TaskEntity
            {
                UserId = taskRequestModel.UserId,
                Title = taskRequestModel.Title,
                Description = taskRequestModel.Description,
                DueDate = taskRequestModel.DueDate,
                Priority = taskRequestModel.Priority,
                Remarks = taskRequestModel.Remarks
            };

            return await _taskRepository.Create(task);
        }

        public async Task<TaskEntity> UpdateTask(TaskUpdateRequestModel taskUpdateRequestModel)
        {
            var task = await _taskRepository.GetById(taskUpdateRequestModel.Id);
            task.Id = taskUpdateRequestModel.Id;
            task.UserId = taskUpdateRequestModel.UserId;
            task.Title = taskUpdateRequestModel.Title;
            task.Description = taskUpdateRequestModel.Description;
            task.DueDate = taskUpdateRequestModel.DueDate;
            task.Priority = taskUpdateRequestModel.Priority;
            task.Remarks = taskUpdateRequestModel.Remarks;
            return await _taskRepository.Update(task);
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null) return false;
            return await _taskRepository.Delete(task);
        }

        public async Task<IEnumerable<TaskResponseModel>> GetTasks()
        {
            var tasks = await _taskRepository.GetAll();
            var taskResponseModels = new List<TaskResponseModel>();
            foreach (var task in tasks)
            {
                taskResponseModels.Add(new TaskResponseModel
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Priority = task.Priority,
                    Remarks = task.Remarks
                });
            }

            return taskResponseModels;
        }

        public async Task<TaskResponseModel> GetTaskById(int id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null)
            {
                return null;
            }

            var taskResponseModel = new TaskResponseModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Remarks = task.Remarks
            };
            return taskResponseModel;
        }

        public async Task<bool> CompleteTask(int id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null) return false;

            var taskHistory = new TaskHistory()
            {
                UserId = task.UserId,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Remarks = task.Remarks,
                Completed = DateTime.Now,
            };
            await _taskHistoryRepository.Create(taskHistory);
            return await DeleteTask(id);
        }
    }
}
