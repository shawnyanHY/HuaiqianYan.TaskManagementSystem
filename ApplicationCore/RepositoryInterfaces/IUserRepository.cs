using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        public Task<IEnumerable<User>> GetMostCompletedUser();
        public Task<IEnumerable<User>> GetMostTaskUser();
        public Task<User> GetUserByEmail(string email);
    }
}
