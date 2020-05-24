using FluentValidation;
using FluentValidation.Results;
using GSP.Shared.Utils.Application.CQS.Exceptions;
using GSP.Shared.Utils.Application.CQS.Models.Validations;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.Application.CQS.Handlers.Abstracts
{
    public abstract class BaseValidationResponseHandler<TRequest, TResult> : BaseResponseHandler<TRequest, TResult>
        where TRequest : IRequest<TResult>
    {
        private readonly IValidator _validator;

        protected BaseValidationResponseHandler(IValidator validator, ILogger<TRequest> logger)
        : base(logger)
        {
            _validator = validator;
        }

        protected override async Task PreExecuteAsync(TRequest request, CancellationToken ct)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(GetObjectToValidate(request), ct);

            if (!validationResult.IsValid)
            {
                ValidationErrorsResponse validationErrors = new ValidationErrorsResponse
                {
                    Errors = validationResult.Errors.Select(x => new ValidationError
                    {
                        ErrorCode = x.ErrorCode,
                        Message = x.ErrorMessage,
                        Property = x.PropertyName
                    })
                };

                throw new ValidationHandlerException(validationErrors);
            }
        }

        protected virtual object GetObjectToValidate(TRequest request)
        {
            return request;
        }
    }
}