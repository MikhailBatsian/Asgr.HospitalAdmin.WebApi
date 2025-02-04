using FluentValidation;
using System.Text.RegularExpressions;
using Asgr.HospitalAdmin.Application;
using Asgr.HospitalAdmin.WebApi.Models.Request;

namespace Asgr.HospitalAdmin.WebApi.Validators;

public class PatientFilterRequestModelValidator : BaseValidator<PatientFilterRequestModel>
{
    public const string BIRTHDATE_NOT_MUTCH_HL7 = "BirthDate does not match hl7 format";

    public PatientFilterRequestModelValidator()
    {
        RuleFor(x => x.BirthDate)
            .Must(x =>
            {
                var match = Regex.Match(x, Constants.HL7_DATE_FORMAT);
                return DateTime.TryParse(match.Groups[2].Value, out _);
            })
            .When(x => !string.IsNullOrWhiteSpace(x.BirthDate))
            .WithMessage(BIRTHDATE_NOT_MUTCH_HL7);
    }
}
