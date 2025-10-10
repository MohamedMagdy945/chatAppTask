
using Chatapp.Core.Entities;

namespace Chatapp.Core.Interfaces
{
    public interface IGroupRepository : IGenenricRepository<Group>
    {
        Task<int?>  GetCommonGroup(int senderId, int receiverId);
        Task<IReadOnlyList<Group>> getAllGroup();
    }
}
