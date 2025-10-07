
using Chatapp.Core.ServicesInterface;

namespace Chatapp.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IMessageRepository MessageRepository { get; }
        public IGroupRepository GroupRepository { get; }
        public IImageManagmentService ImageManagmentService { get; }
    }
}
