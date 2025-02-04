using FluentValidation;
using FluentValidation.Results;

namespace Asgr.HospitalAdmin.WebApi.Validators;

public class BaseValidator<TModel> : AbstractValidator<TModel>
{
    public const string MODEL_CAN_NOT_BE_NULL = "Input request model can not be null, probably it has been incorrectly parsed";
    public override async Task<ValidationResult> ValidateAsync(ValidationContext<TModel> context, CancellationToken cancellation = default)
    {
        if (context.InstanceToValidate != null)
            return await base.ValidateAsync(context, cancellation);

        var failure = new ValidationFailure(typeof(TModel).Name, MODEL_CAN_NOT_BE_NULL);
        
        return new ValidationResult(new[] { failure });
    }
}
