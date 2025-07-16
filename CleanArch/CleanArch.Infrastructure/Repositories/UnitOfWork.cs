using CleanArch.Domain.Abstraction;
using CleanArch.Infrastructure.Context;

namespace CleanArch.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IMemberRepository? _repository;
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IMemberRepository MemberRepository
        {
            get
            {
                return _repository = _repository ??
                    new MemberRepository(_context);
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
