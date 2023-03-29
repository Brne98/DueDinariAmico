using DueDinariAmico.Application.Interfaces;
using DueDinariAmico.Application.Specifications;
using DueDinariAmico.Core.Entities;
using MediatR;

namespace DueDinariAmico.Application.Queries;

public class GetExchangeRateByDateAndCurrencyQuery : IRequest<ExchangeRateList>
{
    public string Date { get; set; }
    public string Currency { get; set; }
}

public class GetExchangeRateByDateAndCurrencyHandler : IRequestHandler<GetExchangeRateByDateAndCurrencyQuery, ExchangeRateList>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IExchangeRateRepository<ExchangeRateList> _exchangeRateRepository;
    private readonly IHttpClientService _httpClientService;

    public GetExchangeRateByDateAndCurrencyHandler(IExchangeRateRepository<ExchangeRateList> exchangeRateRepository, IExchangeRateService exchangeRateService, IHttpClientService httpClientService)
    {
        _exchangeRateRepository = exchangeRateRepository;
        _exchangeRateService = exchangeRateService;
        _httpClientService = httpClientService;
    }

    public async Task<ExchangeRateList> Handle(GetExchangeRateByDateAndCurrencyQuery query, CancellationToken cancellationToken)
    {
        var specification = new Specification<ExchangeRateList>(x => query.Date == x.Date && query.Currency == x.Currency);
            
        var exchangeRate = await _exchangeRateRepository.GetSingle(specification);
        
        if (exchangeRate.Count > 0) 
            return exchangeRate.FirstOrDefault();

        var exchangeRateDto = await _httpClientService.GetDataFromHttpClient();

        var add = _exchangeRateService.TransformDtoToEntity(exchangeRateDto).Where(x=> x.Currency == query.Currency).FirstOrDefault();
        
        _exchangeRateRepository.AddExchangeRateToDatabase(add);
        
        return add;
    }
}