using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBank.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BaA_BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BaABranch = table.Column<string>(name: "BaA_Branch", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BaANumber = table.Column<string>(name: "BaA_Number", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BaAType = table.Column<int>(name: "BaA_Type", type: "int", nullable: false),
                    BaAHolderName = table.Column<string>(name: "BaA_HolderName", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BaAHolderEmail = table.Column<string>(name: "BaA_HolderEmail", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BaAHolderDocument = table.Column<string>(name: "BaA_HolderDocument", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BaAHolderType = table.Column<int>(name: "BaA_HolderType", type: "int", nullable: false),
                    BaAStatus = table.Column<int>(name: "BaA_Status", type: "int", nullable: false),
                    BaACreatedAt = table.Column<DateTime>(name: "BaA_CreatedAt", type: "datetime(6)", nullable: false),
                    BaAUpdatedAt = table.Column<DateTime>(name: "BaA_UpdatedAt", type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaA_BankAccount", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bal_Balance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BaABankAccountId = table.Column<int>(name: "BaA_BankAccountId", type: "int", nullable: false),
                    BalAvailableAmount = table.Column<double>(name: "Bal_AvailableAmount", type: "double", nullable: false),
                    BalBlockedAmount = table.Column<double>(name: "Bal_BlockedAmount", type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bal_Balance", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaA_BankAccount");

            migrationBuilder.DropTable(
                name: "Bal_Balance");
        }
    }
}
