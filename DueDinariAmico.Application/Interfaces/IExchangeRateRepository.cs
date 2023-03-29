using DueDinariAmico.Application.Specifications;
using DueDinariAmico.Core.Entities;

namespace DueDinariAmico.Application.Interfaces;

public interface IExchangeRateRepository<T> where T : class
{
    public Task<List<T?>> Get(Specification<T> spec = null);
    public Task<List<T?>> GetSingle(Specification<T> spec);
    public void AddExchangeRateToDatabase(ExchangeRateList exchangeRate);

}