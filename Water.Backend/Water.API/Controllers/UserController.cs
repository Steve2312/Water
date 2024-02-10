using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Water.API.DTOs;
using Water.API.Exceptions;
using Water.API.Services.Interfaces;
using Water.API.Utils.Interfaces;

namespace Water.API.Controllers;

[ApiController]
[Route("user")]
public class UserController(IUserService userService, IClaimsPrincipalUtil claimsPrincipalUtil): ControllerBase
{
    [Authorize]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUser()
    {
        var subject = claimsPrincipalUtil.GetNameIdentifier(User);
        var subjectUserMap = await userService.GetUser(subject);

        return Ok(subjectUserMap.User.ToDto());
    }

    
    [Authorize]
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> RegisterUser(RegisterUserDto registerUserDto)
    {
        try
        {
            var subject = claimsPrincipalUtil.GetNameIdentifier(User);
            var subjectUserMap = await userService.RegisterUser(subject, registerUserDto);

            // TODO: Add resource link
            return Created("", subjectUserMap.User.ToDto());
        }
        catch (UserAlreadyRegisteredException)
        {
            return Forbid();
        }
    }
    
}