using Asgr.HospitalAdmin.Application.Patients.Dto;

namespace Asgr.HospitalAdmin.WebApi.Models.Request.Mappers;

public static class PatientRequestModelMapper
{
    public static PatientDto ToDto(this PatientRequestModel requestModel)
    {
        return new PatientDto
        {
            Name = new HumanNameDto
            {
                Id = requestModel.Name.Id,
                Use = requestModel.Name.Use,
                Family = requestModel.Name.Family,
                Given = requestModel.Name.Given
            },
            Gender = requestModel.Gender,
            BirthDate = requestModel.BirthDate,
            Active = requestModel.Active
        };
    }
}
