using System.Text.Json.Serialization;

namespace API_Bank.Domain.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AccountType
{
    PAYMENT = 1,
    CURRENT = 2,
    SAVINGS = 3,
    SALARY = 4
}
