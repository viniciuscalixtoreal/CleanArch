using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Abstraction
{
    public interface IMemberDapperRepository
    {
        Task<IEnumerable<Member>> GetAll();
        Task<Member> GetById(int id);
    }
}
