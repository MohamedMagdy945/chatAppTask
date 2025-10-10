

using Chatapp.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Chatapp.Core.DTO
{
    public record MessageDTO
    {
        public int SenderId { get; set; }

        public int? ReceiverId { get; set; }

        public int? GroupId { get; set; }

        public string? Content { get; set; }

        public IFormFile? FileUrl { get; set; }
    }
    public record ReturnMessageDTO
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int GroupId { get; set; }

        public string? Content { get; set; }

        public string? FileUrl { get; set; }

        public int Type { get; set; }
        public DateTime SentAt { get; set; }

    }

}
