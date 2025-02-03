using Asgr.HospitalAdmin.Domain.DataAccess;
using Asgr.HospitalAdmin.Domain.Patients.Enums;

namespace Asgr.HospitalAdmin.Domain.Patients.Entities;

public class Patient : BaseEntity
{
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public bool Active { get; set; }
    public HumanName Name { get; set; }
}