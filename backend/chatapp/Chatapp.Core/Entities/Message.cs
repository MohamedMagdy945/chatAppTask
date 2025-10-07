
namespace Chatapp.Core.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public User Sender { get; set; } = null!;

        public int GroupId { get; set; } 
        public Group Group { get; set; } = null!;

        public string? Content { get; set; }

        public string? FileUrl { get; set; }

        public MessageType Type { get; set; } = MessageType.Text;

        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}
