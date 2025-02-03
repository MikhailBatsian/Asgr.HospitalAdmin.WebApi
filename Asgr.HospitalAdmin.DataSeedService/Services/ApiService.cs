using Asgr.HospitalAdmin.DataSeedService.Models;
using System.Net.Http.Json;

namespace Asgr.HospitalAdmin.DataSeedService.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;

    public ApiService(string apiUrl)
    {
        _httpClient = new HttpClient();
        _apiUrl = apiUrl;
    }

    public async Task WaitForApiAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Waiting API: {_apiUrl}");

        var retryCount = 0;
        const int maxRetries = 10;
        const int delaySeconds = 5;

        while (!cancellationToken.IsCancellationRequested && retryCount < maxRetries)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, _apiUrl);
                using var response = await _httpClient.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("API is available");
                    return;
                }
            }
            catch
            {
                Console.WriteLine($"API doesn't available. Retry after {delaySeconds} seconds");
            }

            retryCount++;
            await Task.Delay(TimeSpan.FromSeconds(delaySeconds), cancellationToken);
        }

        throw new Exception($"API is not available after {maxRetries} tries!");
    }

    public async Task SendPatientsAsync(List<PatientDto> patients, CancellationToken cancellationToken)
    {
        foreach (var patient in patients)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_apiUrl}/patient", patient, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error has been occurred, response status code: {response.StatusCode}");
            }
        }
    }
}
