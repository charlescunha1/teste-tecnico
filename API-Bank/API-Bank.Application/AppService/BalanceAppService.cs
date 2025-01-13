using API_Bank.Application.Interface;
using API_Bank.Domain.Entities;
using API_Bank.Domain.IRepository;

namespace API_Bank.Application.AppService;

public class BalanceAppService : IBalanceAppService
{
    private readonly IBalanceRepository _balanceRepository;

    public BalanceAppService(IBalanceRepository balanceRepository)
    {
        _balanceRepository = balanceRepository;
    }

    public void CreateBalance(Balance balance, int bankAccountId)
    {
        var newBalance = new Balance
        {
            BankAccountId = bankAccountId,
            AvailableAmount = 0.0M,
            BlockedAmount = 0.0M
        };

        _balanceRepository.CreateBalance(newBalance);
    }

    public Balance GetBankAccountBalance(int balanceId)
    {
        return _balanceRepository.GetBalanceById(balanceId);
    }

    public void UpdateBalance(Balance balance)
    {
        _balanceRepository.UpdateBalance(balance);
    }
}
