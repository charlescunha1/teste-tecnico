namespace API_Bank.Domain.Entities;

public class Balance
{
    public int Id { get; set; }
    public int BankAccountId { get; set; }
    public double AvailableAmount { get; set; }
    public double BlockedAmount { get; set; }
}
