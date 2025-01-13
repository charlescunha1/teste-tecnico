namespace API_Bank.Application.ViewModel;

public class BalanceViewModel
{
    public int BankAccountId { get; set; }
    public decimal AvailableAmount { get; set; }
    public decimal BlockedAmount { get; set; }
}