using Chatapp.Core.Interfaces;
using Chatapp.Core.ServicesInterface;
using Chatapp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chatapp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;
        private readonly AppDbContext _context;
        public IImageManagmentService ImageManagmentService { get; private set; }

        public UnitOfWork(AppDbContext context , IImageManagmentService imageManagmentService)
        {
            _context = context;
            ImageManagmentService = imageManagmentService;
        }
        public IUserRepository UserRepository
            => _userRepository ??= new UserRepository(_context);

    }
}
