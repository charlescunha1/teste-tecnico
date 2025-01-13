using API_Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Bank.Infra.Data.Mapping;

public class BalanceMap : IEntityTypeConfiguration<Balance>
{
    public void Configure(EntityTypeBuilder<Balance> builder)
    {
        builder.HasKey(prop => prop.BalanceId);

        builder.Property(prop => prop.BankAccountId)
               .IsRequired()
               .HasColumnName("BaA_BankAccountId");

        builder.Property(prop => prop.AvailableAmount)
               .IsRequired()
               .HasColumnName("Bal_AvailableAmount");

        builder.Property(prop => prop.BlockedAmount)
               .IsRequired()
               .HasColumnName("Bal_BlockedAmount");


        builder.ToTable("Bal_Balance");
    }
}
