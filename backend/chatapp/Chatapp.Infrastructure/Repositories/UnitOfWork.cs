using Chatapp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chatapp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;
        private readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository
            => _userRepository ??= new UserRepository();
    }
}
