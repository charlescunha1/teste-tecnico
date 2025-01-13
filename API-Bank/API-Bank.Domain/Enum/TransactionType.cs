using System.Text.Json.Serialization;

namespace API_Bank.Domain.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TransactionType
{
    CREDIT = 1,
    DEBIT = 2,
    AMOUNT_HOLD = 3,
    AMOUNT_RELEASE = 4
}