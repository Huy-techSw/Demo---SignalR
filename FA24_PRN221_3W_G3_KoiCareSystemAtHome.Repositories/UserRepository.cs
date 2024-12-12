using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository()
        {
        }

        //public UserRepository(FA24_PRN221_3W_G3_KoiCareSystemAtHomeContext context) => _context = context;

        public async Task<User> CheckLogin(string email, string password)
        {
            var result = await _context.Users.FirstOrDefaultAsync(
                x => x.Email == email && x.Password == password);
            return result;
        }
    }
}
