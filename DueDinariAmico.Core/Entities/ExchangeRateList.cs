using DueDinariAmico.Core.Interfaces;

namespace DueDinariAmico.Core.Entities;

public class ExchangeRateList : ISoftDeletable
{
    public int Id { get; set; }
    public string Currency { get; set; }
    public string Date { get; set; }
    public string? Kup { get; set; }
    public string? Pro { get; set; }
    public string Sre { get; set; }
    public bool IsDeleted { get; set; }
}

// public class ExchangeRateCurrency : BaseEntity
// {
//     public string? Kup { get; set; }
//     public string? Pro { get; set; }
//     public string Sre { get; set; }
// }