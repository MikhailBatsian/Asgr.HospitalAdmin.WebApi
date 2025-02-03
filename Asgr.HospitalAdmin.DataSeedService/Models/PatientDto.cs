using Asgr.HospitalAdmin.DataSeedService.Enums;

namespace Asgr.HospitalAdmin.DataSeedService.Models;

public class PatientDto
{
    public HumanNameDto Name { get; set; }
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; }
}
