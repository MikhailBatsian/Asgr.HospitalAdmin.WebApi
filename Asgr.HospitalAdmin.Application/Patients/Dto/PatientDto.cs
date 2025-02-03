using Asgr.HospitalAdmin.Domain.Patients.Enums;

namespace Asgr.HospitalAdmin.Application.Patients.Dto;

public class PatientDto
{
    public HumanNameDto Name { get; set; }
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; }
}
