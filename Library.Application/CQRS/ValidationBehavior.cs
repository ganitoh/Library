using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace Library.Application.CQRS
{
    public class ValidationBehavior<TReqeust, TResponse>
        : IPipelineBehavior<TReqeust, TResponse>
        where TReqeust : IRequest
    {
        private readonly IEnumerable<IValidator<TReqeust>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TReqeust>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TReqeust request, 
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TReqeust>(request);

            var validationFailures = await Task.WhenAll(
                _validators.Select(validator => validator.ValidateAsync(context)));

            var errors = validationFailures
                .Where(validationResult => !validationResult.IsValid)
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure is not null)
                .ToList<ValidationFailure>();

            if (errors.Any())
                throw new ValidationException(errors);

            return await next();
        }
    }
}
