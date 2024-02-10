using System.Security.Claims;
using Water.API.Exceptions;
using Water.API.Utils.Interfaces;

namespace Water.API.Utils;

public class ClaimsPrincipalUtil: IClaimsPrincipalUtil
{
    public string GetNameIdentifier(ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.Identity?.Name ?? throw new NameIdentifierNotFoundException();
    }
}