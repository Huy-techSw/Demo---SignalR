using System;
using System.IO;
using System.Threading.Tasks;
using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models;
using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace FA24_PRN221_3W_G3_KoiCareSystemAtHome.RazorWebApp.Pages.Ponds
{
    public class CreateModel : PageModel
    {
        private readonly PondService _pondService;
        private readonly IHubContext<SignalRServer> _signalRServer;

        public CreateModel(PondService pondService, IHubContext<SignalRServer> signalRServer)
        {
            _pondService = pondService ?? throw new ArgumentNullException(nameof(pondService));
            _signalRServer = signalRServer ?? throw new ArgumentNullException(nameof(signalRServer));

            // Đảm bảo thư mục upload tồn tại
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }
        }

        [BindProperty]
        public Pond Pond { get; set; } = new Pond();

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Xử lý upload hình ảnh (nếu có)
            if (ImageFile != null)
            {
                var fileName = Path.GetFileName(ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                Pond.ImageUrl = "/uploads/" + fileName; // Lưu đường dẫn hình ảnh vào Pond.ImageUrl
            }

            // Tạo mới hồ cá
            await _pondService.Create(Pond);

            // Gửi thông báo đến tất cả các client qua SignalR khi hồ cá mới được tạo
            await _signalRServer.Clients.All.SendAsync("LoadPond", Pond);

            return RedirectToPage("./Index");
        }
    }
}
