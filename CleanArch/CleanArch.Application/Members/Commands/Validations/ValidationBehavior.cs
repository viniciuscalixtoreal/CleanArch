﻿using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.Members.Commands.Validations
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var faliures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (faliures.Count != 0)
                    throw new FluentValidation.ValidationException(faliures);
            }

            return await next();
        }
    }
}
