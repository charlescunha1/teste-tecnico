﻿using API_Bank.Domain.Enum;

namespace API_Bank.Domain.Entities;

public class BankAccount
{
    public int BankAccountId { get; set; }
    public string Branch { get; set; }
    public string? Number { get; set; }
    public AccountType Type { get; set; }
    public string HolderName { get; set; }
    public string HolderEmail { get; set; }
    public string HolderDocument { get; set; }
    public HolderType HolderType { get; set; }
    public Status? Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual Balance Balance { get; set; }
}