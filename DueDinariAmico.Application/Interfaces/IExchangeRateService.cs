using DueDinariAmico.Application.Queries;
using DueDinariAmico.Core.Entities;

namespace DueDinariAmico.Application.Interfaces;

public interface IExchangeRateService
{
    public List<ExchangeRateList> TransformDtoToEntity(ExchangeRateListDto exchangeRateListDto);
}