using ApplicationCore.RepositoryInterfaces;
using TaskEntity = ApplicationCore.Entities.Task;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementSystemDbContext _dbContext;

        public TaskRepository(TaskManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskEntity> Create(TaskEntity task)
        {
            await _dbContext.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<TaskEntity> Update(TaskEntity task)
        {
            _dbContext.Entry(task).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<bool> Delete(TaskEntity task)
        {
            _dbContext.Set<TaskEntity>().Remove(task);
            var res = await _dbContext.SaveChangesAsync();
            return res > 0;
        }

        public async Task<IEnumerable<TaskEntity>> GetAll(Expression<Func<TaskEntity, bool>> filter = null)
        {
            return filter == null
                ? await _dbContext.Tasks.Include(t => t.User).ToListAsync()
                : await _dbContext.Tasks.Where(filter).Include(t => t.User).ToListAsync();
        }

        public async Task<TaskEntity> GetById(int? id)
        {
            return await _dbContext.Tasks.FindAsync(id);
        }

        public Task<int> Count()
        {
            return _dbContext.Tasks.CountAsync();
        }
    }
}
