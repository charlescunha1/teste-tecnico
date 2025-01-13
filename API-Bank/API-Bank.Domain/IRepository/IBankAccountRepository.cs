using API_Bank.Domain.Entities;

namespace API_Bank.Domain.IRepository;

public interface IBankAccountRepository
{
    BankAccount CreateBankAccount(BankAccount bankAccount);
    BankAccount? GetById(int id);
    BankAccount? GetByNumber(string number);
    IEnumerable<BankAccount> ListBankAccountsByHolderName(string holderName);
    void UpdateBankAccont (BankAccount bankAccount);
    IQueryable<BankAccount> ListBankAccountsByBranch(string branch);

}
