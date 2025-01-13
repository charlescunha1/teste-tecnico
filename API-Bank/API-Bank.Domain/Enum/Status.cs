using System.Text.Json.Serialization;

namespace API_Bank.Domain.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status
{
    ACTIVE = 1,
    BLOCKED = 2,
    FINISHED = 3
}
