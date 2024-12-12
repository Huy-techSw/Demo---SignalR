using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories
{
    public class PondRepository : GenericRepository<Pond>
    {
        public PondRepository() { }

        public async Task<List<Pond>> GetAll()
        {
            var pond = await _context.Ponds.Include(c => c.UserId).ToListAsync();
            return pond;
        }

    }
}
