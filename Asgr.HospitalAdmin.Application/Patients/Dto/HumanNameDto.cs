namespace Asgr.HospitalAdmin.Application.Patients.Dto;

public class HumanNameDto
{
    public Guid Id { get; set; }
    public string Use { get; set; }
    public string Family { get; set; }
    public IList<string> Given { get; set; }
}
