using System.ComponentModel.DataAnnotations;
using Api.JWT.Core;

namespace Api.JWT.Controllers.Models;

public sealed class JWTPostRequest(
    Dictionary<string, string> claims, 
    DateTime expireAt) : IValidatableObject
{
    public Dictionary<string, string> Claims => claims;
    public DateTime ExpireAt => expireAt;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (ExpireAt <= DateTime.UtcNow.AddMinutes(1))
        {
            yield return new ValidationResult("Expire time needs to be set later", [nameof(ExpireAt)]);
        }

        if (Claims.IsNullOrEmpty())
        {
            yield return new ValidationResult("Claims can not be empty", [nameof(Claims)]);
        }

        foreach(KeyValuePair<string, string> claim in Claims)
        {
            if (string.IsNullOrWhiteSpace(claim.Value))
            {
                yield return new ValidationResult($"{claim.Key} cannot be empty", [claim.Key]);
            }
        }
    }
}