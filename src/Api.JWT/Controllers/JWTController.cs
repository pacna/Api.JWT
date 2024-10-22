using Api.JWT.Controllers.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.JWT.Controllers;

public class JWTController(IMediator mediator) : BaseController
{
    [HttpGet("{token}/claims")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(ClaimResponse))]
    public async Task<IActionResult> GetClaimsAsync(string token) => Ok(await mediator.Send(new JWTGetRequest(token).ToQuery()));

    [HttpGet("{id}")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(ClaimResponse))]
    public async Task<IActionResult> GetAsync(string id) => Ok(await mediator.Send(new JtiGetRequest(id).ToQuery()));

    [HttpPost]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(string))]
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