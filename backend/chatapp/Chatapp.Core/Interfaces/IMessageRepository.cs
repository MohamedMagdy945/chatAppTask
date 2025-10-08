using Chatapp.Core.DTO;
using Chatapp.Core.Entities;

namespace Chatapp.Core.Interfaces
{
    public interface IMessageRepository : IGenenricRepository<Message>
    {
        Task<IReadOnlyList<Message>> GetMessagesByGroupIdAsync(int groupId);
    }
}
