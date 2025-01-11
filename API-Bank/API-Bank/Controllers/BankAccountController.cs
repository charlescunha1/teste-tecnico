using API_Bank.Application.Interface;
using API_Bank.Application.ViewModel;
using API_Bank.Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace API_Bank.Controllers;

[Route("api/BankAccounts")]
public class BankAccountController(IBankAccountAppService bankAccountAppService) : BaseController
{
    [HttpPost]
    [Route("CreateBankAccount")]
    public IActionResult CreateBankAccount([FromBody] CreateBankAccountViewModel createBankAccountViewModel)
    {
        return ExecuteAction(() =>
        {
            var accountBank = bankAccountAppService.CreateBankAccount(createBankAccountViewModel);
            return CreatedAtAction(nameof(GetAccountBankById), new { id = accountBank.Id }, accountBank);

        });
    }

    [HttpGet]
    [Route("GetAccountBankById")]

    public IActionResult GetAccountBankById(int id)
    {
        return ExecuteAction(() =>
        {
            var accountBank = bankAccountAppService.GetById(id);
            return Ok(accountBank);
        });
    }

    [HttpGet]
    [Route("GetByNumber/{number}")]
    public IActionResult GetByNumber(string number)
    {
        return ExecuteAction(() =>
        {
            var accountBank = bankAccountAppService.GetByNumber(number);
            return Ok(accountBank);
        });
    }

    [HttpGet]
    [Route("ListBankAccountsByBranch/{branch}")]
    public IActionResult ListBankAccountsByBranch(string branch)
    {
        return ExecuteAction(() =>
        {
            var accountBankList = bankAccountAppService.ListBankAccountsByBranch(branch);
            return Ok(accountBankList);
        });
    }

    [HttpGet]
    [Route("ListBankAccountsByHolderName/{holderName}")]
    public IActionResult ListBankAccountsByHolderName(string holderName)
    {
        return ExecuteAction(() =>
        {
            var accountBankList = bankAccountAppService.ListBankAccountsByHolderName(holderName);
            return Ok(accountBankList);
        });
    }

    [HttpPatch]
    [Route("UpdateEmailByHolderName/{holderName}")]
    public IActionResult UpdateEmailByHolderName(string holderName, [FromBody] string holderEmail)
    {
        return ExecuteAction(() =>
        {
            var updatedEmail = bankAccountAppService.UpdateEmailByHolderName(holderName, holderEmail);
            return Ok(updatedEmail);
        });
    }

    [HttpPatch]
    [Route("UpdateStatusByNumber/{number}")]
    public IActionResult UpdateStatusByNumber(string number, [FromBody] Status status)
    {
        return ExecuteAction(() =>
        {
            var updatedStatus = bankAccountAppService.UpdateStatusByNumber(number, status);
            return Ok(updatedStatus);
        });
    }

    [HttpDelete]
    [Route("CloseBankAccount/{number}")]
    public IActionResult CloseBankAccount(string number)
    {
        return ExecuteAction(() =>
        {
            bankAccountAppService.CloseBankAccount(number);
            return Ok($"Conta bancária com número {number} foi fechada.");
        });
    }

    [HttpPost]
    [Route("BlockAmountFromAccount/{number}")]
    public IActionResult BlockAmountFromAccount(string number, [FromBody] double amount)
    {
        return ExecuteAction(() =>
        {
            bankAccountAppService.BlockAmountFromAccount(number, amount);
            return Ok($"Quantia de {amount} foi bloqueada na conta com número {number}.");
        });
    }

    [HttpPost]
    [Route("UnblockAmountFromAccount/{number}")]
    public IActionResult UnblockAmountFromAccount(string number, [FromBody] double amount)
    {
        return ExecuteAction(() =>
        {
            bankAccountAppService.UnblockAmountFromAccount(number, amount);
            return Ok($"Quantia de {amount} foi desbloqueada na conta com número {number}.");
        });
    }

    [HttpPost]
    [Route("DepositToAccount/{number}")]
    public IActionResult DepositToAccount(string number, [FromBody] double amount)
    {
        return ExecuteAction(() =>
        {
            bankAccountAppService.DepositToAccount(number, amount);
            return Ok($"Quantia de {amount} foi depositada na conta com número {number}.");
        });
    }

    [HttpPost]
    [Route("DebitAccount/{number}")]
    public IActionResult DebitAccount(string number, [FromBody] double amount)
    {
        return ExecuteAction(() =>
        {
            bankAccountAppService.DebitAccount(number, amount);
            return Ok($"Quantia de {amount} foi debitada da conta com número {number}.");
        });
    }
}

