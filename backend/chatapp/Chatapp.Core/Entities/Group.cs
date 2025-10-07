
namespace Chatapp.Core.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? GroupImagePath { get; set; }
        public ICollection<GroupMember> Members { get; set; } = new List<GroupMember>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
