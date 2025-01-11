using API_Bank.Application.Interface;
using API_Bank.Application.ViewModel;
using API_Bank.Domain.Enum;

namespace API_Bank.Application.AppService;

public class BankAccountAppService : IBankAccountAppService
{
    public void BlockAmountFromAccount(string number, double amount)
    {
        throw new NotImplementedException();
    }

    public void CloseBankAccount(string number)
    {
        throw new NotImplementedException();
    }

    public BankAccountsViewModel CreateBankAccount(CreateBankAccountViewModel createBankAccountViewModel)
    {
        throw new NotImplementedException();
    }

    public void DebitAccount(string number, double amount)
    {
        throw new NotImplementedException();
    }

    public void DepositToAccount(string number, double amount)
    {
        throw new NotImplementedException();
    }

    public BankAccountsViewModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public BankAccountsViewModel GetByNumber(string number)
    {
        throw new NotImplementedException();
    }

    public List<BankAccountsViewModel> ListBankAccountsByBranch(string branch)
    {
        throw new NotImplementedException();
    }

    public List<BankAccountsViewModel> ListBankAccountsByHolderName(string holderName)
    {
        throw new NotImplementedException();
    }

    public void UnblockAmountFromAccount(string number, double amount)
    {
        throw new NotImplementedException();
    }

    public BankAccountsViewModel UpdateEmailByHolderName(string holderName, string holderEmail)
    {
        throw new NotImplementedException();
    }

    public BankAccountsViewModel UpdateStatusByNumber(string number, Status status)
    {
        throw new NotImplementedException();
    }
}
