using Asgr.HospitalAdmin.DataSeedService.DataGenerators;
using Asgr.HospitalAdmin.DataSeedService.Services;

namespace Asgr.HospitalAdmin.DataSeedService;

public class DataSeedFlow
{
    private readonly ApiService _apiService;

    public DataSeedFlow(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task Execute(int generatedPatientsCount)
    {
        Console.WriteLine("Sending generated data to API");

        var patients = PatientGenerator.GeneratePatients(generatedPatientsCount);

        await _apiService.WaitForApiAsync(CancellationToken.None);
        await _apiService.SendPatientsAsync(patients, CancellationToken.None);

        Console.WriteLine("Done!");
    }
}
