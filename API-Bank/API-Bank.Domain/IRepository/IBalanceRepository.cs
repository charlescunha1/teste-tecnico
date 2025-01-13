using API_Bank.Domain.Entities;

namespace API_Bank.Domain.IRepository;

public interface IBalanceRepository
{
    void UpdateBalance(Balance balance);
    void CreateBalance(Balance balance);
    Balance GetBalanceById(int balanceId);
}