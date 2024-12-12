using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models;
using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Services;

namespace FA24_PRN221_3W_G3_KoiCareSystemAtHome.RazorWebApp.Pages.Ponds
{
    public class EditModel : PageModel
    {
        private readonly FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models.FA24_PRN221_3W_G3_KoiCareSystemAtHomeContext _context;
        private readonly PondService _pondService;
        public EditModel(PondService pondService)
        {
            _pondService = pondService;
        }

        [BindProperty]
        public Pond Pond { get; set; } = default!;

        [BindProperty]
        public IFormFile ImageFile { get; set; }


        public async Task<IActionResult> OnGetAsync(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pond =  await _pondService.GetByIdLong(id);
            if (pond == null)
            {
                return NotFound();
            }
            Pond = pond;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Pond).State = EntityState.Modified;
            if (ImageFile != null)
            {
                var fileName = Path.GetFileName(ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Ensure the directory exists

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                Pond.ImageUrl = "/uploads/" + fileName; // Save the file path as a string
            }

            try
            {
                await _pondService.Update(Pond);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
                //if (!ModelState.IsValid)
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return RedirectToPage("./Index");
        }

        //private bool PondExists(long id)
        //{
        //    return _context.Ponds.Any(e => e.Id == id);
        //}
    }
}
