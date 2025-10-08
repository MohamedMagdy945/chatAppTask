
using Chatapp.Core.Entities;
using Chatapp.Core.Interfaces;
using Chatapp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chatapp.Infrastructure.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Message>> GetMessagesByGroupIdAsync(int groupId)
        {
            return await _context.Messages
                .Where(m => m.GroupId == groupId)
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }
    }
}
