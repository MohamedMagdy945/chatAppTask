using Microsoft.AspNetCore.Http;

namespace Chatapp.Core.DTO
{
    public record UserDTO
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public IFormFile? ProfileImage { get; set; } 

    }
    public record ReturnUserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ProfileImagePath { get; set; } = null!;

    }
}
