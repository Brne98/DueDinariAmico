using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DueDinariAmico.Application.Queries;

public class ExchangeRateListDto
{
    [JsonProperty("result")]
    public Result Result { get; set; }
}

public class Result
{
    [JsonProperty("date")]
    public string Date { get; set; }
    [JsonProperty("eur")]
    public ExchangeRate Eur { get; set; }
    [JsonProperty("usd")]
    public ExchangeRate Usd { get; set; }
    [JsonProperty("chf")]
    public ExchangeRate Chf { get; set; }
}

public class ExchangeRate
{
    [JsonProperty("kup")]
    public string? Kup { get; set; }
    [JsonProperty("sre")]
    public string Sre { get; set; }
    [JsonProperty("pro")]
    public string? Pro { get; set; }
}

// {
// "result": {
//     "date": "27.03.2023",
//     "eur": {
//         "kup": "116.9868",
//         "sre": "117.3388",
//         "pro": "117.6908"
//         },
//     "usd": {
//         "kup": "108.643",
//         "sre": "108.9699",
//         "pro": "109.2968"
//         },
//     "chf": {
//         "kup": "118.2521",
//         "sre": "118.6079",
//         "pro": "118.9637"
//         }
//     }
// }