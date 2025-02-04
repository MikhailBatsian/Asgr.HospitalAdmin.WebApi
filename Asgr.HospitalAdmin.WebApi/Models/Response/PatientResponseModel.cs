using Asgr.HospitalAdmin.Application.Patients.Dto;

namespace Asgr.HospitalAdmin.WebApi.Models.Response;

public class PatientResponseModel
{
    public HumanNameDto Name { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; }
}
