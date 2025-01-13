using API_Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Bank.Infra.Data.Mapping;

public class BankAccountMap : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.HasKey(prop => prop.BankAccountId);

        builder.Property(prop => prop.Branch)
            .IsRequired()
            .HasColumnName("BaA_Branch");

        builder.Property(prop => prop.Number)
            .IsRequired()
            .HasColumnName("BaA_Number");

        builder.Property(prop => prop.Type)
            .IsRequired()
            .HasColumnName("BaA_Type");

        builder.Property(prop => prop.HolderName)
            .IsRequired()
            .HasColumnName("BaA_HolderName");

        builder.Property(prop => prop.HolderEmail)
            .IsRequired()
            .HasColumnName("BaA_HolderEmail");

        builder.Property(prop => prop.HolderDocument)
            .IsRequired()
            .HasColumnName("BaA_HolderDocument");

        builder.Property(prop => prop.HolderType)
            .IsRequired()
            .HasColumnName("BaA_HolderType");

        builder.Property(prop => prop.Status)
            .IsRequired()
            .HasColumnName("BaA_Status");

        builder.Property(prop => prop.CreatedAt)
            .IsRequired()
            .HasColumnName("BaA_CreatedAt");

        builder.Property(prop => prop.UpdatedAt)
            .IsRequired()
            .HasColumnName("BaA_UpdatedAt");

        builder.HasOne(prop => prop.Balance)
            .WithOne(prop => prop.BankAccount)
            .HasForeignKey<Balance>(prop => prop.BankAccountId);


        builder.ToTable("BaA_BankAccount");
    }
}
