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
                    BankAccountId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_BaA_BankAccount", x => x.BankAccountId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bal_Balance",
                columns: table => new
                {
                    BalanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BalAvailableAmount = table.Column<double>(name: "Bal_AvailableAmount", type: "double", nullable: false),
                    BalBlockedAmount = table.Column<double>(name: "Bal_BlockedAmount", type: "double", nullable: false),
                    BaABankAccountId = table.Column<int>(name: "BaA_BankAccountId", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bal_Balance", x => x.BalanceId);
                    table.ForeignKey(
                        name: "FK_Bal_Balance_BaA_BankAccount_BaA_BankAccountId",
                        column: x => x.BaABankAccountId,
                        principalTable: "BaA_BankAccount",
                        principalColumn: "BankAccountId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Bal_Balance_BaA_BankAccountId",
                table: "Bal_Balance",
                column: "BaA_BankAccountId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bal_Balance");

            migrationBuilder.DropTable(
                name: "BaA_BankAccount");
        }
    }
}
