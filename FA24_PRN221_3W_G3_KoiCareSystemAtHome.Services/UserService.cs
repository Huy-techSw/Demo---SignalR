using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories;
using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA24_PRN221_3W_G3_KoiCareSystemAtHome.Services
{

    public interface IUserService
    {
        Task<User> Login(string email, string password);
    }
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository ??= new UserRepository();
        }

        public async Task<User> Login(string email, string password)
        {
            return await _userRepository.CheckLogin(email, password);
        }
    }

}
