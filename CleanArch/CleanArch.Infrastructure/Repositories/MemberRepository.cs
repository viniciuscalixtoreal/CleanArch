using CleanArch.Domain.Abstraction;
using CleanArch.Domain.Entities;
using CleanArch.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        protected readonly ApplicationDbContext _context;

        public MemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member> GetById(int id)
        {
            var member = await _context.Members.FirstOrDefaultAsync(x => x.Id == id);

            if (member == null)
                throw new InvalidOperationException("Member not found.");

            return member;
        }

        public async Task<Member> Add(Member member)
        {
            if (member is null) 
                throw new ArgumentNullException(nameof(member));

            await _context.Members.AddAsync(member);
            return member;
        }

        public void Update(Member member)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));

            _context.Update(member);
        }

        public async Task<Member> Delete(int id)
        {
            var member = _context.Members.FirstOrDefault(x => x.Id == id);

            if (member is null)
                throw new ArgumentNullException(nameof(id));

            _context.Members.Remove(member);
            return member;
        }
    }
}
