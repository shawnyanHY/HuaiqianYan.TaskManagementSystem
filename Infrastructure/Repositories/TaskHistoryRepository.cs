﻿using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TaskHistoryRepository : ITaskHistoryRepository
    {
        private readonly TaskManagementSystemDbContext _dbContext;

        public TaskHistoryRepository(TaskManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskHistory> Create(TaskHistory obj)
        {
            await _dbContext.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<TaskHistory> Update(TaskHistory taskHistory)
        {
            _dbContext.Entry(taskHistory).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return taskHistory;
        }

        public async Task<bool> Delete(TaskHistory taskHistory)
        {
            _dbContext.Set<TaskHistory>().Remove(taskHistory);
            var res = await _dbContext.SaveChangesAsync();
            return res > 0;
        }

        public async Task<IEnumerable<TaskHistory>> GetAll(Expression<Func<TaskHistory, bool>> filter = null)
        {
            return filter == null
                ? await _dbContext.TaskHistories.OrderByDescending(t => t.Completed).Include(th => th.User)
                    .ToListAsync()
                : await _dbContext.TaskHistories.OrderByDescending(t => t.Completed).Where(filter)
                    .Include(th => th.User).ToListAsync();
        }

        public async Task<TaskHistory> GetById(int? id)
        {
            return await _dbContext.TaskHistories.FindAsync(id);
        }

        public Task<int> Count()
        {
            return _dbContext.TaskHistories.CountAsync();
        }

        public async Task<IEnumerable<TaskHistory>> GetRecent()
        {
            return await _dbContext.TaskHistories.OrderByDescending(t => t.Completed).Take(10).ToListAsync();
        }
    }
}
