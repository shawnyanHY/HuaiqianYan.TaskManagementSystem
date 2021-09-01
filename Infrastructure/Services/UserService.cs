using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUser(UserRequestModel userRequestModel)
        {
            var user = new User
            {
                Email = userRequestModel.Email,
                Password = userRequestModel.Password,
                FullName = userRequestModel.FullName,
                MobileNo = userRequestModel.MobileNo
            };
            return await _userRepository.Create(user);
        }

        public async Task<User> UpdateUser(UserUpdateRequestModel userRequestModel)
        {
            var user = await _userRepository.GetById(userRequestModel.Id);
            user.Email = userRequestModel.Email;
            user.FullName = userRequestModel.FullName;
            user.MobileNo = userRequestModel.MobileNo;
            if (userRequestModel.Password != null) user.Password = userRequestModel.Password;
            return await _userRepository.Update(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null) return false;
            return await _userRepository.Delete(user);
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            var userResponseModels = new List<UserResponseModel>();
            foreach (var user in users)
            {
                userResponseModels.Add(new UserResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    MobileNo = user.MobileNo
                });
            }

            return userResponseModels;
        }

        public async Task<UserResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return null;
            }
            var userResponseModels = new UserResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                MobileNo = user.MobileNo
            };
            return userResponseModels;
        }
    }
}
