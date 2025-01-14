using API_Bank.Application.Interface;
using API_Bank.Application.ViewModel;
using API_Bank.Domain.Entities;
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
        // Verifique se o modelo é válido
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return ExecuteAction(() =>
        {
            var accountBank = bankAccountAppService.CreateBankAccount(createBankAccountViewModel);
            return Ok(accountBank);

        });
    }

    [HttpGet]
    [Route("GetBankAccountById/{id}")]

    public IActionResult GetBankAccountById(int id)
    {
        return ExecuteAction(() =>
        {
            var accountBank = bankAccountAppService.GetById(id);
            return Ok(accountBank);
        });
    }

    [HttpGet]
    [Route("GetBankAccountBalance/{holderNumber}")]

    public IActionResult GetBankAccountBalance(string holderNumber)
    {
        return ExecuteAction(() =>
        {
            var balances = bankAccountAppService.GetBankAccountBalance(holderNumber);
            return Ok(balances);
        });
    }

    [HttpGet]
    [Route("GetBankAccountByNumber/{number}")]
    public IActionResult GetBankAccountByNumber(string number)
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
    [Route("UpdateEmailByHolderName/{number}")]
    public IActionResult UpdateEmailByNumber(string number, [FromBody] string holderEmail)
    {
        return ExecuteAction(() =>
        {
            bankAccountAppService.UpdateEmailByNumber(number, holderEmail);
            return Ok("Email atualizado com sucesso !");
        });
    }

    [HttpPatch]
    [Route("UpdateStatusByNumber/{number}")]
    public IActionResult UpdateStatusByNumber(string number, [FromBody] Status status)
    {
        return ExecuteAction(() =>
        {
            bankAccountAppService.UpdateStatusByNumber(number, status);
            return Ok("Status atualizado com sucesso !");
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
    public IActionResult BlockAmountFromAccount(string number, [FromBody] decimal amount)
    {
        return ExecuteAction(() =>
        {
            bankAccountAppService.BlockAmountFromAccount(number, amount);
            return Ok($"Quantia de {amount} foi bloqueada na conta com número {number}.");
        });
    }

    [HttpPost]
    [Route("UnblockAmountFromAccount/{number}")]
    public IActionResult UnblockAmountFromAccount(string number, [FromBody] decimal amount)
    {
        return ExecuteAction(() =>
        {
            bankAccountAppService.UnblockAmountFromAccount(number, amount);
            return Ok($"Quantia de {amount} foi desbloqueada na conta com número {number}.");
        });
    }

    [HttpPost]
    [Route("DepositToAccount/{number}")]
    public IActionResult DepositToAccount(string number, [FromBody] AmountViewModel amountViewModel)
    {
        return ExecuteAction(() =>
        {
            bankAccountAppService.DepositToAccount(number, amountViewModel);
            return Ok($"Quantia de {amountViewModel.Amount} foi depositada na conta com número {number}.");
        });
    }

    [HttpPost]
    [Route("DebitAccount/{number}")]
    public IActionResult DebitAccount(string number, [FromBody] decimal amount)
    {
        return ExecuteAction(() =>
        {
            bankAccountAppService.DebitAccount(number, amount);
            return Ok($"Quantia de {amount} foi debitada da conta com número {number}.");
        });
    }

    [HttpPost]
    [Route("DebitAccountById/{id}")]
    public IActionResult DebitAccount(int id, [FromBody] AmountViewModel amountViewModel)
    {
        return ExecuteAction(() =>
        {
            bankAccountAppService.DebitAccountById(id, amountViewModel);
            return Ok($"Quantia de {amountViewModel.Amount} foi debitada da conta com id {id}.");
        });
    }




    //[HttpGet("/balance/{id}")]
    //public IActionResult GetBalance(int id)
    //{
    //    return ExecuteAction(() =>
    //    {
    //        var balance = bankAccountAppService.GetBalance(id);
    //        return Ok(balance);
    //    });
    //}
}

