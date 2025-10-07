using Chatapp.Core.Interfaces;
using Chatapp.Core.ServicesInterface;
using Chatapp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chatapp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;
        private IGroupRepository _groupRepository;
        private IMessageRepository _messasgeRepository;
        private readonly AppDbContext _context;
        public IImageManagmentService ImageManagmentService { get; private set; }

        public UnitOfWork(AppDbContext context , IImageManagmentService imageManagmentService)
        {
            _context = context;
            ImageManagmentService = imageManagmentService;
        }
        public IUserRepository UserRepository
            => _userRepository ??= new UserRepository(_context);
        public IGroupRepository GroupRepository
       => _groupRepository ??= new GroupRepository(_context);

        public IMessageRepository MessageRepository
       => _messasgeRepository ??= new MessageRepository(_context);
    }
}
