
using Chatapp.Core.Entities;
using Chatapp.Core.Interfaces;
using Chatapp.Infrastructure.Data;

namespace Chatapp.Infrastructure.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {
        }
    }

}
