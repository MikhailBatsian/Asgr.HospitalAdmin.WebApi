using Asgr.HospitalAdmin.Application.Patients.Dto;

namespace Asgr.HospitalAdmin.WebApi.Models.Response.Mappers;

public static class PatientResponseModelMapper
{
    public static PatientResponseModel ToResponse(this PatientDto dto)
    {
        return new PatientResponseModel
        {
            Name = new HumanNameDto
            {
                Id = dto.Name.Id,
                Use = dto.Name.Use,
                Family = dto.Name.Family,
                Given = dto.Name.Given
            },
            Gender = dto.Gender.ToString().ToLower(),
            BirthDate = dto.BirthDate,
            Active = dto.Active
        };
    }
}
