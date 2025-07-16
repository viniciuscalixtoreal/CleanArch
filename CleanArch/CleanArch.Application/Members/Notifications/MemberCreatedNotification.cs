using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Members.Notifications
{
    public class MemberCreatedNotification : INotification
    {
        public Member Member { get; }

        public MemberCreatedNotification(Member member) 
        { 
            Member = member; 
        }
    }
}
