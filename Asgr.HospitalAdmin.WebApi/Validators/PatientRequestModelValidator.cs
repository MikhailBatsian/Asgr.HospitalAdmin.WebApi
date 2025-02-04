using FluentValidation;
using Asgr.HospitalAdmin.Domain.Patients.Enums;
using Asgr.HospitalAdmin.WebApi.Models.Request;

namespace Asgr.HospitalAdmin.WebApi.Validators;

public class PatientRequestModelValidator : BaseValidator<PatientRequestModel>
{
    public const string NAME_FAMILY_REQUIRED_MESSAGE = "Name.Family is required";
    public const string BIRTHDATE_REQUIRED_MESSAGE = "BirthDate is required";
    public const string GENDER_INCORRECT_MESSAGE = "Gender can be only : male | female | other | unknown";

    public PatientRequestModelValidator()
    {
        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .WithMessage(BIRTHDATE_REQUIRED_MESSAGE);

        RuleFor(x => x.Name.Family)
            .NotEmpty()
            .WithMessage(NAME_FAMILY_REQUIRED_MESSAGE);

        RuleFor(x => x.Gender)
            .Must(x => Enum.TryParse<Gender>(x, ignoreCase: true, out _))
            .WithMessage(GENDER_INCORRECT_MESSAGE);
    }
}
