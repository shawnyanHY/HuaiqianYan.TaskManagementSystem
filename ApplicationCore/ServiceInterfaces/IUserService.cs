using ApplicationCore.Entities;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        public Task<User> AddUser(UserRequestModel user);

        public Task<User> UpdateUser(UserUpdateRequestModel user);

        public Task<bool> DeleteUser(int id);

        public Task<IEnumerable<UserResponseModel>> GetAllUsers();

        public Task<UserResponseModel> GetUserById(int id);
    }
}
