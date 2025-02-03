using Asgr.HospitalAdmin.Domain.DataAccess;

namespace Asgr.HospitalAdmin.Domain.Patients.Entities;

public class HumanName : BaseEntity
{
    public string Use { get; set; }
    public string Family { get; set; }
    public IList<string> Given { get; set; }
    public Guid PatientId { get; set; }

    public Patient Patient { get; set; }
}
