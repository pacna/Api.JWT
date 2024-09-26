using Microsoft.AspNetCore.Mvc;

namespace Api.JWT.Controllers;

public class JWTController : BaseController
{
    [HttpGet("claims")]
    public async Task<IActionResult> SearchClaimsAsync()
    {
        return Ok(await Task.Run(() => "hi"));
    }

    [HttpPost]
    public async Task<IActionResult> CreateJWTAsync()
    {
        return Ok(await Task.Run(() => "HI"));
    }

    [HttpDelete("{token}")]
    public async Task<IActionResult> DeleteJWTAsync()
    {
        return Ok(await Task.Run(() => "HI"));
    }
}