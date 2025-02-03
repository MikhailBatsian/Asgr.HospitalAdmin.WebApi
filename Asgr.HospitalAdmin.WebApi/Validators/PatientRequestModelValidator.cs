using Asgr.HospitalAdmin.WebApi.Models.Request;
using FluentValidation;

namespace Asgr.HospitalAdmin.WebApi.Validators;

public class PatientRequestModelValidator : AbstractValidator<PatientRequestModel>
{
    public const string NAME_FAMILY_REQUIRED_MESSAGE = "Name.Family is required";
    public const string BIRTHDATE_REQUIRED_MESSAGE = "Birthdate is required";

    public PatientRequestModelValidator()
    {
        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .WithMessage(BIRTHDATE_REQUIRED_MESSAGE);

        RuleFor(x => x.Name.Family)
            .NotEmpty()
            .WithMessage(NAME_FAMILY_REQUIRED_MESSAGE);
    }
}
