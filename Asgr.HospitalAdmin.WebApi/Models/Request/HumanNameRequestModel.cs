namespace Asgr.HospitalAdmin.WebApi.Models.Request;

public class HumanNameRequestModel
{
    public Guid Id { get; set; }
    public string Use { get; set; }
    public string Family { get; set; }
    public List<string> Given { get; set; }
}

