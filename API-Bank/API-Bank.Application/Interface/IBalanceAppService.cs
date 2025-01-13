using API_Bank.Domain.Entities;

namespace API_Bank.Application.Interface;

public interface IBalanceAppService
{
    void UpdateBalance(Balance balance);
    void CreateBalance(Balance balance, int bankAccountId);
    Balance GetBankAccountBalance(int balanceId);
}
