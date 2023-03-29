using DueDinariAmico.Application.Exceptions;
using DueDinariAmico.Application.Queries;
using Newtonsoft.Json;

namespace DueDinariAmico.Infrastructure.HttpClients;

public class ExchangeRateHttpClient
{
    private const string AppId = "5cb7e61783820d240b11ae84583080d4";
    private const string Url = "https://api.kursna-lista.info";
    private readonly HttpClient _httpClient;

    public ExchangeRateHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ExchangeRateListDto> TodayExchangeRate()
    {
        var url = $"{Url}/{AppId}/kursna_lista/json"; 
            
        var result = await _httpClient.GetAsync(url);
            
        if (!result.IsSuccessStatusCode)
            throw new ApiException("Unable to exchange rate.", 500);
            
        var resultAsString = await result.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ExchangeRateListDto>(resultAsString);
    }
}