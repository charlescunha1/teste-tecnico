using API_Bank.Domain.Entities;
using API_Bank.Domain.IRepository;
using API_Bank.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API_Bank.Infra.Data.Repository;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly BankAccountContext _context;

    public BankAccountRepository(BankAccountContext context)
    {
        _context = context;
    }

    public BankAccount CreateBankAccount(BankAccount bankAccount)
    {
        _context.BankAccount.Add(bankAccount);
        _context.SaveChanges();
        return bankAccount;
    }

    public BankAccount? GetByNumber(string number)
    {
        return _context.Set<BankAccount>()
            .Include(x => x.Balance)
            .FirstOrDefault(x => x.Number == number);
    }

    public BankAccount? GetById(int id)
    {
        return _context.Set<BankAccount>().Include(x => x.Balance)
            .FirstOrDefault(x => x.BankAccountId == id);
    }

    public IQueryable<BankAccount> ListBankAccountsByBranch(string branch)
    {
        return _context.Set<BankAccount>()
            .Include(x => x.Balance)
            .Where(x => x.Branch == branch)
            .AsQueryable();
    }

    public IEnumerable<BankAccount> ListBankAccountsByHolderName(string holderName)
    {
        return _context.Set<BankAccount>()
            .Include(x => x.Balance)
            .Where(x => x.HolderName == holderName)
            .ToList()
            .AsEnumerable();
    }

    public BankAccount UpdateEmailByHolderName(string holderName, string holderEmail)
    {
        var bankAccount = _context.BankAccount.FirstOrDefault(x => x.HolderName == holderName);
        bankAccount!.HolderEmail = holderEmail;
        _context.SaveChanges();
        return bankAccount;
    }

    //public BankAccount UpdateStatusByNumber(string number, Status status)
    //{
    //    var bankAccount = _context.BankAccount.FirstOrDefault(x => x.Number == number);
    //    bankAccount!.Status = status;
    //    _context.SaveChanges();
    //    return bankAccount;
    //}

    //public void CloseBankAccount(BankAccount bankAccount)
    //{
    //    _context.BankAccount.Update(bankAccount);
    //    _context.SaveChanges();
    //}

    public void UpdateBankAccont(BankAccount bankAccount)
    {
        bankAccount.UpdatedAt = DateTime.Now;
        _context.BankAccount.Update(bankAccount);
        _context.SaveChanges();
    }


}
