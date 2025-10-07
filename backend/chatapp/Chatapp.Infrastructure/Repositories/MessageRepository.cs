
using Chatapp.Core.Entities;
using Chatapp.Core.Interfaces;
using Chatapp.Infrastructure.Data;

namespace Chatapp.Infrastructure.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }
    }
}
