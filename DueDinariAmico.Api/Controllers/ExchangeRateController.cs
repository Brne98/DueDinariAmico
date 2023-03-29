using DueDinariAmico.Application.Exceptions;
using DueDinariAmico.Application.Queries;
using DueDinariAmico.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DueDinariAmico.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangeRateController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExchangeRateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<ExchangeRateList>> GetAll()
    {
        return await _mediator.Send(new GetExchangeRateListQuery());
    }

    [HttpGet("find-single")]
    public async Task<ExchangeRateList> GetSingle(DateTime date, string currency)
    {
        string search = date.ToString("dd.MM.yyyy");

        if (string.IsNullOrWhiteSpace(search) || string.IsNullOrWhiteSpace(currency))
            throw new ApiException("Date and currency are required!", 400);

        return await _mediator.Send(new GetExchangeRateByDateAndCurrencyQuery { Date = search, Currency = currency });
    }
    
    [HttpGet("date")]
    public async Task<List<ExchangeRateList>> GetListByDate(DateTime date)
    {
        string search = date.ToString("dd.MM.yyyy");

        return await _mediator.Send(new GetExchangeRateByDateQuery { Date = search });
    }
    
    [HttpGet("currency")]
    public async Task<List<ExchangeRateList>> GetListByCurrency(string currency)
    {
        return await _mediator.Send(new GetExchangeRateByCurrancyQuery { Currency = currency });
    }
}