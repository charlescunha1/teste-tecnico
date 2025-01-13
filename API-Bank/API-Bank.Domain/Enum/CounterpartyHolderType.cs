using System.Text.Json.Serialization;

namespace API_Bank.Domain.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CounterpartyHolderType
{
    NATURAL = 1,
    LEGAL = 2
}
