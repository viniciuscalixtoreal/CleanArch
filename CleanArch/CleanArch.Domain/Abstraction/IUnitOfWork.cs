namespace CleanArch.Domain.Abstraction
{
    public interface IUnitOfWork
    {
        IMemberRepository MemberRepository { get; }
        Task CommitAsync();
    }
}
