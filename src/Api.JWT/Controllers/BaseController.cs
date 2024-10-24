using Microsoft.AspNetCore.Mvc;

namespace Api.JWT.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class BaseController : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult OkIfFound<TResult>(TResult result)
    {
        return result == null
            ? NotFound()
            : Ok(result);
    }
}