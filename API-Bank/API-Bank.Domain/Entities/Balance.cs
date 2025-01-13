namespace API_Bank.Domain.Entities;

public class Balance
{
    public int BalanceId { get; set; }
    public decimal AvailableAmount { get; set; }
    public decimal BlockedAmount { get; set; }
    public virtual BankAccount BankAccount { get; set; }
    public int BankAccountId { get; set; }
}
