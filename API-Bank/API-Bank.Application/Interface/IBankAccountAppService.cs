using API_Bank.Application.ViewModel;
using API_Bank.Domain.Entities;
using API_Bank.Domain.Enum;

namespace API_Bank.Application.Interface;

public interface IBankAccountAppService
{
    BankAccountsViewModel CreateBankAccount(CreateBankAccountViewModel createBankAccountViewModel);
    BankAccountsViewModel GetById(int id);
    BankAccountsViewModel GetByNumber(string number);
    List<BankAccountsViewModel> ListBankAccountsByBranch(string branch);
    List<BankAccountsViewModel> ListBankAccountsByHolderName(string holderName);
    void UpdateEmailByNumber(string number, string holderEmail);
    void UpdateStatusByNumber(string number, Status status);
    void CloseBankAccount(string number);
    void DepositToAccount(string number, AmountViewModel amountViewModel);
    void DebitAccount(string number, decimal amount);
    void BlockAmountFromAccount(string number, decimal amount);
    void UnblockAmountFromAccount(string number, decimal amount);
    BalanceViewModel GetBankAccountBalance(string holderNumber);
    BalanceViewModel GetBalance(int id);
    void DebitAccountById(int id, AmountViewModel amountViewModel);
}
