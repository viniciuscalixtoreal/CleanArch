using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Members.Notifications
{
    public class MemberCreatedSMSHandler : INotificationHandler<MemberCreatedNotification>
    {
        private readonly ILogger<MemberCreatedSMSHandler> _logger;
        public MemberCreatedSMSHandler(ILogger<MemberCreatedSMSHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(MemberCreatedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Confirmation SMS sent for: {notification.Member.FirstName}");
            return Task.CompletedTask;
        }
    }
}
