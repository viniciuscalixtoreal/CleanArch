using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Abstraction
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAll();
        Task<Member> GetById(int id);
        Task<Member> Add(Member member);
        void Update(Member member);
        Task<Member> Delete(int id);
    }
}
