using API_Bank.Application.Interface;
using API_Bank.Application.ViewModel;
using API_Bank.Domain.Entities;
using API_Bank.Domain.Enum;
using API_Bank.Domain.IRepository;
using AutoMapper;
using System.Globalization;
using System.Text.RegularExpressions;

namespace API_Bank.Application.AppService;

public class BankAccountAppService : IBankAccountAppService
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly IBalanceAppService _balanceAppService;
    private IMapper _mapper;

    public BankAccountAppService(IBankAccountRepository bankAccountRepository, IMapper mapper, IBalanceAppService balanceAppService)
    {
        _bankAccountRepository = bankAccountRepository;
        _balanceAppService = balanceAppService;
        _mapper = mapper;
    }

    public void DepositToAccount(string number, decimal amount)
    {
        IsValidAmount(amount);
        var bankAccount = ValidateBankAccountNumber(number);
        bankAccount.Balance.AvailableAmount += amount;
        _balanceAppService.UpdateBalance(bankAccount.Balance);
    }

    public void DebitAccount(string number, decimal amount)
    {
        var bankAccount = ValidateBankAccountNumber(number);
        ValidateAmount(bankAccount.Balance, amount);
        bankAccount.Balance.AvailableAmount -= amount;
        _balanceAppService.UpdateBalance(bankAccount.Balance);
    }

    public void BlockAmountFromAccount(string number, decimal amount)
    {
        var bankAccount = ValidateBankAccountNumber(number);
        ValidateAmount(bankAccount.Balance, amount);

        bankAccount.Balance.BlockedAmount += amount;
        bankAccount.Balance.AvailableAmount -= amount;
        _balanceAppService.UpdateBalance(bankAccount.Balance);
    }

    public void UnblockAmountFromAccount(string number, decimal amount)
    {
        var bankAccount = ValidateBankAccountNumber(number);
        ValidateAmountToUnblock(bankAccount.Balance, amount);

        bankAccount.Balance.AvailableAmount += amount;
        bankAccount.Balance.BlockedAmount -= amount;
        _balanceAppService.UpdateBalance(bankAccount.Balance);
    }

    private void ValidateAmount(Balance balance, decimal amount)
    {
        if (balance.AvailableAmount < amount) throw new Exception("Saldo insuficiente !");
    }

    private void ValidateAmountToUnblock(Balance balance, decimal amount)
    {
        if (amount > balance.BlockedAmount) throw new Exception("Saldo bloqueado insuficiente !");
    }

    public void CloseBankAccount(string number)
    {
        var accountBank = ValidateBankAccountNumber(number);
        accountBank.Status = Status.FINISHED;
        _bankAccountRepository.UpdateBankAccont(accountBank);
    }

    public BankAccountsViewModel CreateBankAccount(CreateBankAccountViewModel createBankAccountViewModel)
    {
        IsDuplicateAccountTypeExist(createBankAccountViewModel);

        var bankAccount = _mapper.Map<BankAccount>(createBankAccountViewModel);
        bankAccount.Number = GenerateRandomNumber(5, 10);
        var bankAccountCreated = _bankAccountRepository.CreateBankAccount(bankAccount);

        _balanceAppService.CreateBalance(bankAccountCreated.Balance, bankAccountCreated.BankAccountId);
        return _mapper.Map<BankAccountsViewModel>(bankAccountCreated);
    }

    public BankAccountsViewModel GetById(int id)
    {
        var bankAccount = _bankAccountRepository.GetById(id);
        return _mapper.Map<BankAccountsViewModel>(bankAccount);
    }

    public BankAccountsViewModel GetByNumber(string number)
    {
        var bankAccount = ValidateBankAccountNumber(number);
        return _mapper.Map<BankAccountsViewModel>(bankAccount);
    }

    public List<BankAccountsViewModel> ListBankAccountsByBranch(string branch)
    {
        var bankAccountsList = _bankAccountRepository.ListBankAccountsByBranch(branch);
        return _mapper.Map<List<BankAccountsViewModel>>(bankAccountsList);
    }

    public List<BankAccountsViewModel> ListBankAccountsByHolderName(string holderName)
    {
        var bankAccountsList = _bankAccountRepository.ListBankAccountsByHolderName(holderName);
        return _mapper.Map<List<BankAccountsViewModel>>(bankAccountsList);
    }

    public void UpdateEmailByNumber(string number, string holderEmail)
    {
        var bankAccount = ValidateBankAccountNumber(number);
        bankAccount.HolderEmail = holderEmail;
        _bankAccountRepository.UpdateBankAccont(bankAccount);
    }

    public void UpdateStatusByNumber(string number, Status status)
    {
        var bankAccount = ValidateBankAccountNumber(number);
        bankAccount.Status = status;
        _bankAccountRepository.UpdateBankAccont(bankAccount);
    }

    private BankAccount ValidateBankAccountNumber(string number)
    {
        var bankAccount = _bankAccountRepository.GetByNumber(number);
        if (bankAccount == null)
        {
            throw new Exception($"não existe conta bancaria com número {number}");
        }
        if (bankAccount.Status != Status.ACTIVE)
        {
            throw new Exception($"Não é possível realizar essa operação pois a conta está {bankAccount.Status}");
        }
        return bankAccount;
    }

    private static string GenerateRandomNumber(int minDigits, int maxDigits)
    {
        Random random = new Random();
        int numberOfDigits = random.Next(minDigits, maxDigits + 1);
        string randomNumberStr = "";

        for (int i = 0; i < numberOfDigits; i++)
        {
            randomNumberStr += random.Next(0, 10).ToString();
        }
        return randomNumberStr;
    }

    private void IsDuplicateAccountTypeExist(CreateBankAccountViewModel createBankAccountViewModel)
    {
        var accountType = createBankAccountViewModel.Type;
        var bankAccounts = _bankAccountRepository.ListBankAccountsByHolderName(createBankAccountViewModel.HolderName);
        var bankAccountDuplicate = bankAccounts.Where(x => x.Type == accountType);
        if (bankAccountDuplicate.Any())
        {
            throw new Exception($"Já existe uma conta do tipo {accountType} para esse usuário");
        }
    }

    public BalanceViewModel GetBankAccountBalance(string holderNumber)
    {
        var bankAccount = ValidateBankAccountNumber(holderNumber);
        var balances = _balanceAppService.GetBankAccountBalance(bankAccount.Balance.BalanceId);
        return _mapper.Map<BalanceViewModel>(balances);
    }

    public void IsValidAmount(decimal amount)
    {
        var amountStr = amount.ToString("F2", CultureInfo.InvariantCulture);
        var regex = new Regex(@"^\d{1,16}(\.\d{0,2})?$");

        var isValidAmount = regex.IsMatch(amountStr);
        if (!isValidAmount)
        {
            throw new Exception("Valor monetário inválido. Deve ter no máximo 16 dígitos antes da vírgula e 2 após.");
        }
    }

    public BalanceViewModel GetBalance(int id)
    {
        var balance = _balanceAppService.GetBankAccountBalance(id);
        return _mapper.Map<BalanceViewModel>(balance);
    }
}
