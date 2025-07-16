using CleanArch.Application.Members.Notifications;
using CleanArch.Domain.Abstraction;
using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Members.Commands
{
    public class CreateMemberCommand : MemberCommandBase
    {
        public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Member>
        {
            private readonly IUnitOfWork _unitOfWork;
            private IMediator _mediator;

            public CreateMemberCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
            {
                _unitOfWork = unitOfWork;
                _mediator = mediator;
            }

            public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
            {
                var newMember = new Member(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive);

                await _unitOfWork.MemberRepository.Add(newMember);
                await _unitOfWork.CommitAsync();

                await _mediator.Publish(new MemberCreatedNotification(newMember));

                return newMember;
            }
        }
    }
}
