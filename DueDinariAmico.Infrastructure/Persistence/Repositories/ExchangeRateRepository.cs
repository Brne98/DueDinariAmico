using DueDinariAmico.Application.Interfaces;
using DueDinariAmico.Application.Specifications;
using DueDinariAmico.Core.Entities;
using DueDinariAmico.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DueDinariAmico.Infrastructure.Persistence.Repositories;

public class ExchangeRateRepository<T> : IExchangeRateRepository<T> where T : class
{
    private readonly DataContext _context;

    public ExchangeRateRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<T?>> Get(Specification<T> spec = null)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<List<T?>> GetSingle(Specification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public void AddExchangeRateToDatabase(ExchangeRateList exchangeRate)
    {
        if (!DateExistsInDatabase(exchangeRate.Date, exchangeRate.Currency))
        {
            _context.Add(exchangeRate);
            _context.SaveChanges();
        }
    }

    private bool DateExistsInDatabase(string date, string currency)
    {
        var dbDate = _context.ExchangeRateLists.Where(erl => erl.Date == date && erl.Currency == currency);

        if (dbDate.Any())
            return true;

        return false;
    }

    private IQueryable<T?> ApplySpecification(Specification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }
}