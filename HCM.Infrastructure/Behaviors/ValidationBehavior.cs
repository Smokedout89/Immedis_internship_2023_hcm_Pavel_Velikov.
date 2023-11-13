namespace HCM.Infrastructure.Behaviors;

using MediatR;
using Requests;
using Responses;
using FluentValidation;
using Microsoft.AspNetCore.Http;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : BaseRequest
    where TResponse : IResult
{
    private readonly IValidator<TRequest> _validator;

    public ValidationBehavior(IValidator<TRequest> validator)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(
            request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = string.Format(
                string.Join(
                Environment.NewLine,
                validationResult.Errors.Select(
                    x => x.ErrorMessage)));

            return (TResponse)Response.BadRequest(errors);
        }
        
        return await next();
    }
}