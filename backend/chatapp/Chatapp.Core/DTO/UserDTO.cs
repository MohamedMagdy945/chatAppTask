using Microsoft.AspNetCore.Http;

namespace Chatapp.Core.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public IFormFile? ProfileImage { get; set; } 

    }
}
