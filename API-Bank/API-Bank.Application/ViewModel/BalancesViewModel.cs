namespace API_Bank.Application.ViewModel;

public class BalancesViewModel
{
    public int BankAccountId { get; set; }
    public double AvailableAmount { get; set; }
    public double BlockedAmount { get; set; }
}
