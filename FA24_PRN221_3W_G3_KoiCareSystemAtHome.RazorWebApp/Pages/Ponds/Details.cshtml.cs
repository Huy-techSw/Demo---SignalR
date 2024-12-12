using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models;
using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Services;

namespace FA24_PRN221_3W_G3_KoiCareSystemAtHome.RazorWebApp.Pages.Ponds
{
    public class DetailsModel : PageModel
    {
        private readonly FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models.FA24_PRN221_3W_G3_KoiCareSystemAtHomeContext _context;
        private readonly PondService _pondService;

        public DetailsModel(PondService pondService)
        {
            _pondService = pondService;
        }

        public Pond Pond { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pond = await _pondService.GetByIdLong(id);
            if (pond == null)
            {
                return NotFound();
            }
            else
            {
                Pond = pond;
            }
            return Page();
        }
    }
}
