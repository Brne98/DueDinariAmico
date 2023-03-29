using DueDinariAmico.Application.Interfaces;
using DueDinariAmico.Application.Specifications;
using DueDinariAmico.Core.Entities;
using MediatR;

namespace DueDinariAmico.Application.Queries;

public class GetExchangeRateByDateQuery : IRequest<List<ExchangeRateList>>
{
    public string Date { get; set; }
    public string Currency { get; set; }
}

public class GetExchangeRateByDateHandler : IRequestHandler<GetExchangeRateByDateQuery, List<ExchangeRateList>>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IExchangeRateRepository<ExchangeRateList> _exchangeRateRepository;
    private readonly IHttpClientService _httpClientService;

    public GetExchangeRateByDateHandler(IExchangeRateRepository<ExchangeRateList> exchangeRateRepository, IExchangeRateService exchangeRateService, IHttpClientService httpClientService)
    {
        _exchangeRateRepository = exchangeRateRepository;
        _exchangeRateService = exchangeRateService;
        _httpClientService = httpClientService;
    }

    public async Task<List<ExchangeRateList>> Handle(GetExchangeRateByDateQuery query, CancellationToken cancellationToken)
    {
        var specification = new Specification<ExchangeRateList>(x => query.Date == x.Date);
            
        var exchangeRate = await _exchangeRateRepository.GetSingle(specification);
        
        if (exchangeRate.Count > 0) 
            return exchangeRate;

        var exchangeRateDto = await _httpClientService.GetDataFromHttpClient();

        var adds = _exchangeRateService.TransformDtoToEntity(exchangeRateDto);

        foreach (var add in adds)
        {
            _exchangeRateRepository.AddExchangeRateToDatabase(add);
        }
        
        return adds;
    }
}