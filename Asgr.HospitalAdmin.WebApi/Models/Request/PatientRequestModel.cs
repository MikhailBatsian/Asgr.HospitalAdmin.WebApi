using Asgr.HospitalAdmin.Domain.Patients.Enums;

namespace Asgr.HospitalAdmin.WebApi.Models.Request;

public class PatientRequestModel
{
    public HumanNameRequestModel Name { get; set; }
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; }
}
