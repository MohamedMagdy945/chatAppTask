
using Chatapp.Core.Entities;

namespace Chatapp.Core.Interfaces
{
    public interface IUserRepository : IGenenricRepository<User>
    {
        Task<bool> EmailExistsAsync(string email);

    }
}   
