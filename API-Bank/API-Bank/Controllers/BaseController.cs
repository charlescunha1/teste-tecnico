using API_Bank.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API_Bank.Controllers;

public class BaseController : ControllerBase
{
    protected IActionResult ExecuteAction(Func<IActionResult> action)
    {
        try
        {
            return action();
        }
        catch (Exception ex)
        {
            return CreateErrorResponse(ex);
        }
    }

    private ObjectResult CreateErrorResponse(Exception ex)
    {
        if (ex is KeyNotFoundException)
        {
            return StatusCode(StatusCodes.Status404NotFound, new ResponseViewModel()
            {
                Status = StatusCodes.Status404NotFound,
                Error = ex.Message
            });
        }

        return StatusCode(StatusCodes.Status400BadRequest, new ResponseViewModel()
        {
            Status = StatusCodes.Status400BadRequest,
            Error = ex.Message
        });
    }
}
