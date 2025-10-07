using Microsoft.AspNetCore.Http;

namespace Chatapp.Core.ServicesInterface
{
    public interface IImageManagmentService
    {
        Task<string> AddImageAsync(IFormFile file);
    }
}
