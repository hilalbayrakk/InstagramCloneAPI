using InstagramCloneAPI.Interfaces;
using InstagramCloneAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace InstagramCloneAPI.Service
{
    public class UserService : ControllerBase, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository useriRepository)
        {
            _userRepository = useriRepository;
        }
        public async Task<User> AddUser(User user)
        {
            var result = await _userRepository.GetUserByUserName(user.UserName);
            if (result == null)
            {
                return await _userRepository.AddUser(user);
            }
            throw new InvalidOperationException("Bu kullanici adi baska bir kullanici tarafindan kullaniliyor!");
        }

        public async Task DeleteUser(User user)
        {
            var result = _userRepository.GetUserById(user.Id);
            if (result != null)
            {
                await _userRepository.DeleteUser(user);
            }
            throw new Exception("Silinecek kullanici bulunamadi!");
        }

        public async Task<User> UpdateUser(User user, int id)
        {
            var result = await _userRepository.GetUserById(id);
            if (result != null)
            {
                result = user;
                await _userRepository.UpdateUser(user);
                return user;
            }
            throw new InvalidOperationException("Guncellenecek kullanici bulunamadi!");
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _userRepository.GetAllUser();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _userRepository.GetUserById(userId);
        }
        public async Task<User> GetUserByUserName(string userName)
        {
            var result = _userRepository.GetUserByUserName(userName);
            if (result != null)
            {
                return await result;
            }
            throw new InvalidOperationException("Kullanici bulunamadi!");
        }

        public async Task<User> GetUserByAccountId(int accountId)
        {
            return await _userRepository.GetUserByAccountId(accountId);
        }
        public async Task<List<User>> GetAllUserByGenderId(int genderId)
        {
            return await _userRepository.GetAllUserByGenderId(genderId);
        }

    }
}
