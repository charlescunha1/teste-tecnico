using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using API_Bank.Infra.Data.Context;

namespace API_Bank.Infra.Data.Context
{

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BankAccountContext>
    {
        public BankAccountContext CreateDbContext(string[] args)
        {
            // Configura o DbContextOptions manualmente para design-time
            var optionsBuilder = new DbContextOptionsBuilder<BankAccountContext>();

            // String de conexão (ajuste conforme necessário)
            var connectionString = "Server=localhost;Port=3306;Database=Transactionsdb;User=root;Password=root;";

            // Usando o pacote Pomelo.EntityFrameworkCore.MySql
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new BankAccountContext(optionsBuilder.Options);
        }
    }
}
