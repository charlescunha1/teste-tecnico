﻿namespace API_Bank.Application.ViewModel;

public class TransactionRequestViewModel
{
    public TypeTransaction TypeTransaction { get; set; }
    public Double Amount { get; set; }
    public int BankAccountId { get; set; }
    public string CounterpartyBankCode { get; set; }
    public string CounterpartyBankName { get; set; }
    public string CounterpartyBranch { get; set; }
    public CounterpartyAccountType CounterpartyAccountType { get; set; }
    public string CounterpartyHolderName { get; set; }
    public CounterpartyHolderType CounterpartyHolderType { get; set; }
    public string CounterpartyHolderDocument { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
