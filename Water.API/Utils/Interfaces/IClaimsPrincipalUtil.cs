using System.Security.Claims;

namespace Water.API.Utils.Interfaces;

public interface IClaimsPrincipalUtil
{
    string GetNameIdentifier(ClaimsPrincipal claimsPrincipal);
}