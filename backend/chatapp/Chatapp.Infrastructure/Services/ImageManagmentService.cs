using Chatapp.Core.DTO;
using Chatapp.Core.Entities;
using Chatapp.Core.ServicesInterface;
using Microsoft.AspNetCore.Http;

namespace Chatapp.Infrastructure.Services
{
    public class ImageManagmentService : IImageManagmentService
    {
        public async Task<string> AddImageAsync(IFormFile file)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return  $"uploads/" + fileName;
        }
    }
}
