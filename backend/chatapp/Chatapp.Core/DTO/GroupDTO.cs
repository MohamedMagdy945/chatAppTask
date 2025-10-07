

using Microsoft.AspNetCore.Http;

namespace Chatapp.Core.DTO
{
    public record GroupDTO
    {
        public string Name { get; set; } = null!;
        public int UserCreatedId { get; set; }
        public IFormFile? GroupImage { get; set; }
    }
    public record SubscribeGroupDTO
    {
        public int SubscribeUserId { get; set; }
        public int GroupId { get; set; }
    }
}
