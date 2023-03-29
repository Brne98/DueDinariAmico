using DueDinariAmico.Application.Interfaces;
using DueDinariAmico.Application.Specifications;
using DueDinariAmico.Core.Entities;
using MediatR;

namespace DueDinariAmico.Application.Queries;

public class GetExchangeRateListQuery : IRequest<List<ExchangeRateList>>
{
    
}

public class GetExchangeRateListHandler : IRequestHandler<GetExchangeRateListQuery, List<ExchangeRateList>>
{
    private readonly IExchangeRateRepository<ExchangeRateList?> _exchangeRateRepository;

    public GetExchangeRateListHandler(IExchangeRateRepository<ExchangeRateList?> exchangeRateRepository)
    {
        _exchangeRateRepository = exchangeRateRepository;
    }

    public async Task<List<ExchangeRateList?>> Handle(GetExchangeRateListQuery query, CancellationToken cancellationToken)
    {
        var specification = new Specification<ExchangeRateList?>();
        return await _exchangeRateRepository.Get(specification);
    }
}