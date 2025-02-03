namespace Asgr.HospitalAdmin.Application.Patients.Filters;

public class PatientFilter
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
    public string BirthdayHl7 { get; set; }
}
