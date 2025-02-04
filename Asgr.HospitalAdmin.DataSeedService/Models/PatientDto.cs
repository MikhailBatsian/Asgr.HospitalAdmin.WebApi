﻿namespace Asgr.HospitalAdmin.DataSeedService.Models;

public class PatientDto
{
    public HumanNameDto Name { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; }
}
