
namespace Chatapp.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
    }
}
