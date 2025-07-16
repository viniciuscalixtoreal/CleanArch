using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Members.Notifications
{
    public class MemberCreatedEmailHandler : INotificationHandler<MemberCreatedNotification>
    {
        private readonly ILogger<MemberCreatedEmailHandler> _logger;
        public MemberCreatedEmailHandler(ILogger<MemberCreatedEmailHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(MemberCreatedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Confirmation email sent for: {notification.Member.FirstName}");
            return Task.CompletedTask;
        }
    }
}
