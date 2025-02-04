using Asgr.HospitalAdmin.DataSeedService.Enums;
using Bogus;
using Asgr.HospitalAdmin.DataSeedService.Models;

namespace Asgr.HospitalAdmin.DataSeedService.DataGenerators;

internal static class PatientGenerator
{
    public static List<PatientDto> GeneratePatients(int count)
    {
        var faker = new Faker<PatientDto>()
            .RuleFor(p => p.Name, f => new HumanNameDto
            {
                Family = f.Name.LastName(),
                Use = f.Random.String2(5, 50),
                Given = new List<string> { f.Name.FirstName(), f.Name.FirstName() }
            })
            .RuleFor(p => p.Gender, f => f.PickRandom(Gender.Male, Gender.Female, Gender.Other, Gender.Unknown).ToString().ToLower())
            .RuleFor(p => p.BirthDate, f => f.Date.Past(5, DateTime.UtcNow))
            .RuleFor(p => p.Active, f => f.Random.Bool());

        return faker.Generate(count);
    }
}
