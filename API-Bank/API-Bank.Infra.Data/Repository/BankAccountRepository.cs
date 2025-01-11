using API_Bank.Domain.Entities;
using API_Bank.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Bank.Infra.Data.Repository;

public class BankAccountRepository
{
    private readonly BankAccountContext _context;

    public BankAccountRepository(BankAccountContext context)
    {
        _context = context;
    }

    //public BankAccount CreateBankAccount(BankAccount bankAccount)
    //{
    //    _context.BankAccount.Add(bankAccount);
    //    _context.SaveChanges();
    //}
}
