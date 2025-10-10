
using Chatapp.Core.Entities;
using Chatapp.Core.Interfaces;
using Chatapp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chatapp.Infrastructure.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Group>> getAllGroup()
        {
            return await _context.Groups.Where(g => g.Name != "" ).ToListAsync();
        }

        public async Task<int?> GetCommonGroup(int senderId, int receiverId)
        {
            var groupId = await (
                    from gm1 in _context.GroupMembers
                    join gm2 in _context.GroupMembers
                        on gm1.GroupId equals gm2.GroupId
                    where gm1.UserId == senderId
                          && gm2.UserId == receiverId
                          && gm1.privateGroup == true
                    select gm1.GroupId
                ).FirstOrDefaultAsync();

            return groupId == 0 ? null : groupId;
        }
    }

}
