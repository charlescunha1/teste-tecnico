using API_Bank.Domain.Entities;
using API_Bank.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace API_Bank.Infra.Data.Context;

public class BankAccountContext : DbContext
{
    public BankAccountContext(DbContextOptions<BankAccountContext> options) : base(options)
    {
      
    }

    public DbSet<BankAccount> BankAccount { get; set; }
    public DbSet<Balance> Balance { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<BankAccount>(new BankAccountMap().Configure);
        modelBuilder.Entity<Balance>(new BalanceMap().Configure);
    }
}
