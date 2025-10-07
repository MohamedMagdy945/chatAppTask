
namespace Chatapp.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();
    }
}  
