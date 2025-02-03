using Asgr.HospitalAdmin.DataSeedService.Services;
using System.Text.Json;

namespace Asgr.HospitalAdmin.DataSeedService;

internal class Program
{
    static async Task Main(string[] args)
    {
        const string API_URL = "ApiUrl";
        const string GENERATED_PATIENTS_COUNT = "GeneratedPatientsCount";
        
        var settingsStr = await File.ReadAllTextAsync("appsettings.json");
        var config = JsonSerializer.Deserialize<Dictionary<string, string>>(settingsStr);
        
        var apiUrl = Environment.GetEnvironmentVariable(API_URL) ?? config[API_URL];
        var generatedPatientsCountStr = Environment.GetEnvironmentVariable(GENERATED_PATIENTS_COUNT) ?? config[GENERATED_PATIENTS_COUNT];
        var generatedPatientsCount = int.Parse(generatedPatientsCountStr);

        var dataSeedFlow = new DataSeedFlow(new ApiService(apiUrl));
        await dataSeedFlow.Execute(generatedPatientsCount);
    }
}
