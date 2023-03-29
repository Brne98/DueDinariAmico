using DueDinariAmico.Application.Interfaces;
using DueDinariAmico.Application.Queries;
using DueDinariAmico.Infrastructure.HttpClients;

namespace DueDinariAmico.Infrastructure.Services;

public class HttpClientService : IHttpClientService
{
    private readonly ExchangeRateHttpClient _exchangeRateHttpClient;

    public HttpClientService(ExchangeRateHttpClient exchangeRateHttpClient)
    {
        _exchangeRateHttpClient = exchangeRateHttpClient;
    }

    public async Task<ExchangeRateListDto> GetDataFromHttpClient()
    {
        var exchangeRate = await _exchangeRateHttpClient.TodayExchangeRate();
        
        CheckForZeroProperties(exchangeRate);
        
        return exchangeRate;
    }

    private void CheckForZeroProperties(ExchangeRateListDto exchangeRate)
    {
        if (exchangeRate.Result.Eur.Kup == "0")
            exchangeRate.Result.Eur.Kup = null;

        if (exchangeRate.Result.Eur.Pro == "0")
            exchangeRate.Result.Eur.Pro = null;
        
        if (exchangeRate.Result.Usd.Kup == "0")
            exchangeRate.Result.Usd.Kup = null;

        if (exchangeRate.Result.Usd.Pro == "0")
            exchangeRate.Result.Usd.Pro = null;
        
        if (exchangeRate.Result.Chf.Kup == "0")
            exchangeRate.Result.Chf.Kup = null;

        if (exchangeRate.Result.Chf.Pro == "0")
            exchangeRate.Result.Chf.Pro = null;
    }
}