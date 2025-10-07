

using Microsoft.AspNetCore.Http;

namespace Chatapp.Core.DTO
{
    public class MessageDTO
    {

        public int SenderId { get; set; }

        public int? ReceiverId { get; set; }

        public int? GroupId { get; set; }

        public string? Content { get; set; }

        public IFormFile? FileUrl { get; set; }
    }

}
