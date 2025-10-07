
using Chatapp.Core.ServicesInterface;

namespace Chatapp.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IImageManagmentService ImageManagmentService { get; }
    }
}
