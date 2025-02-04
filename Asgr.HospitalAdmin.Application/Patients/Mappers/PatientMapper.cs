using Asgr.HospitalAdmin.Application.Patients.Dto;
using Asgr.HospitalAdmin.Domain.Patients.Entities;

namespace Asgr.HospitalAdmin.Application.Patients.Mappers;

public static class PatientMapper
{
    public static Patient ToEntity(this PatientDto dto)
    {
        return new Patient
        {
            Id = dto.Name.Id,
            Name = dto.Name.ToEntity(),
            Gender = dto.Gender,
            BirthDate = DateTime.SpecifyKind(dto.BirthDate, DateTimeKind.Utc),
            Active = dto.Active
        };
    }

    public static PatientDto ToDto(this Patient patient)
    {
        if (patient == null) return null;

        return new PatientDto
        {
            Name = patient.Name.ToDto(),
            Gender = patient.Gender,
            BirthDate = patient.BirthDate,
            Active = patient.Active
        };
    }
}
