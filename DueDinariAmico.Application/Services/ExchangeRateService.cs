using DueDinariAmico.Application.Interfaces;
using DueDinariAmico.Application.Queries;
using DueDinariAmico.Core.Entities;

namespace DueDinariAmico.Application.Services;


public class ExchangeRateService : IExchangeRateService
{
    public List<ExchangeRateList> TransformDtoToEntity(ExchangeRateListDto exchangeRateListDto)
    {
        var exchangeRateEur = new ExchangeRateList
        {
            Date = exchangeRateListDto.Result.Date,
            Currency = "eur",
            Kup = exchangeRateListDto.Result.Eur.Kup,
            Sre = exchangeRateListDto.Result.Eur.Sre,
            Pro = exchangeRateListDto.Result.Eur.Pro,
        };
        
        var exchangeRateUsd = new ExchangeRateList
        {
            Date = exchangeRateListDto.Result.Date,
            Currency = "usd",
            Kup = exchangeRateListDto.Result.Usd.Kup,
            Sre = exchangeRateListDto.Result.Usd.Sre,
            Pro = exchangeRateListDto.Result.Usd.Pro,
        };
        
        var exchangeRateChf = new ExchangeRateList
        {
            Date = exchangeRateListDto.Result.Date,
            Currency = "chf",
            Kup = exchangeRateListDto.Result.Chf.Kup,
            Sre = exchangeRateListDto.Result.Chf.Sre,
            Pro = exchangeRateListDto.Result.Chf.Pro,
        };

        return new List<ExchangeRateList> { exchangeRateEur, exchangeRateUsd, exchangeRateChf};
    }
}