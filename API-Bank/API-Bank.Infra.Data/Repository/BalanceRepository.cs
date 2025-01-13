using API_Bank.Domain.Entities;
using API_Bank.Domain.IRepository;
using API_Bank.Infra.Data.Context;

namespace API_Bank.Infra.Data.Repository;

public class BalanceRepository : IBalanceRepository
{
    private readonly BankAccountContext _context;

    public BalanceRepository(BankAccountContext context)
    {
        _context = context;
    }
    public void UpdateBalance(Balance balance)
    {
        _context.Balance.Update(balance);
        _context.SaveChanges();
    }

    public void CreateBalance(Balance balance)
    {
        _context.Balance.Add(balance);
        _context.SaveChanges();
    }

    public Balance GetBalanceById(int balanceId)
    {
        return _context.Set<Balance>().FirstOrDefault(x => x.BalanceId == balanceId)!;
    }
}