
namespace Chatapp.Core.Entities
{
    public class GroupMember
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public bool privateGroup { get; set; } = true;
    }
}
