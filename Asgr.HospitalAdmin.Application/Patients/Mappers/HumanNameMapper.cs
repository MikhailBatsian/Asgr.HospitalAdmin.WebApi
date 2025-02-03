using Asgr.HospitalAdmin.Application.Patients.Dto;
using Asgr.HospitalAdmin.Domain.Patients.Entities;

namespace Asgr.HospitalAdmin.Application.Patients.Mappers;

internal static class HumanNameMapper
{
    public static HumanName ToEntity(this HumanNameDto dto)
    {
        return new HumanName
        {
            Id = dto.Id,
            Use = dto.Use,
            Family = dto.Family,
            Given = dto.Given
        };
    }

    public static HumanNameDto ToDto(this HumanName name)
    {
        return new HumanNameDto
        {
            Id = name.Id,
            Use = name.Use,
            Family = name.Family,
            Given = name.Given
        };
    }
}
