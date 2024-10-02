using Api.JWT.Controllers.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.JWT.Controllers;

public class JWTController(IMediator mediator) : BaseController
{
    [HttpGet("{token}/claims")]
    public async Task<IActionResult> GetClaimsAsync(string token)
    {
        return Ok(await Task.Run(() => "hi"));
    }

    [HttpPost]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(ClaimResponse))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateJWTAsync([FromBody] JWTPostRequest request) => Ok(await mediator.Send(request.ToCommand()));

    [HttpDelete("{token}")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteJWTAsync(string token)
    {
        await mediator.Publish(new JWTDeleteRequest(token).ToCommand());
        return NoContent();
    }
}