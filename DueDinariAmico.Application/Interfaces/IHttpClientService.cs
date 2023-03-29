using DueDinariAmico.Application.Queries;

namespace DueDinariAmico.Application.Interfaces;

public interface IHttpClientService
{
    Task<ExchangeRateListDto> GetDataFromHttpClient();
}