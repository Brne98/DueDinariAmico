using DueDinariAmico.Application.Interfaces;
using DueDinariAmico.Core.Entities;
using Quartz;

namespace DueDinariAmico.Infrastructure.BackgroundProcesses;

public class AddExchangeRateToDatabase : IJob
{
    private readonly IExchangeRateService _service;
    private readonly IHttpClientService _httpService;
    private readonly IExchangeRateRepository<ExchangeRateList> _repository;

    public AddExchangeRateToDatabase(IExchangeRateRepository<ExchangeRateList> repository, IExchangeRateService service, IHttpClientService httpService)
    {
        _repository = repository;
        _service = service;
        _httpService = httpService;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var exchangeRateDto = await _httpService.GetDataFromHttpClient();

        var adds = _service.TransformDtoToEntity(exchangeRateDto);
        foreach (var add in adds)
        {
            _repository.AddExchangeRateToDatabase(add);

        }
    }
}