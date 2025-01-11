using API_Bank.Application.ViewModel;
using API_Bank.Domain.Enum;

namespace API_Bank.Application.Interface;

public interface IBankAccountAppService
{
    BankAccountsViewModel CreateBankAccount(CreateBankAccountViewModel createBankAccountViewModel);
    BankAccountsViewModel GetById(int id);
    BankAccountsViewModel GetByNumber(string number);
    List<BankAccountsViewModel> ListBankAccountsByBranch(string branch);
    List<BankAccountsViewModel> ListBankAccountsByHolderName(string holderName);
    BankAccountsViewModel UpdateEmailByHolderName(string holderName, string holderEmail);
    BankAccountsViewModel UpdateStatusByNumber(string number, Status status);
    void CloseBankAccount(string number);
    void BlockAmountFromAccount(string number, double amount);
    void UnblockAmountFromAccount(string number, double amount);
    void DepositToAccount(string number, double amount);
    void DebitAccount(string number, double amount);
}
