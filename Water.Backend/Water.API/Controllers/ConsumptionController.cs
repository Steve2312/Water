using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Water.API.DTOs;
using Water.API.Exceptions;
using Water.API.Services.Interfaces;
using Water.API.Utils.Interfaces;

namespace Water.API.Controllers;

[ApiController]
[Route("consumption")]
public class ConsumptionController(IClaimsPrincipalUtil claimsPrincipalUtil, IUserService userService, IConsumptionService consumptionService): ControllerBase
{
    [Authorize]
    [HttpGet("recommended/daily")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MillilitersDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDailyRecommendedConsumption()
    {
        var subject = claimsPrincipalUtil.GetNameIdentifier(User);
        var subjectUserMap = await userService.GetUser(subject);
        var milliliters = consumptionService.GetDailyRecommendedConsumption(subjectUserMap.User);

        return Ok(milliliters);
    }
    
    [Authorize]
    [HttpGet("total/daily")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MillilitersDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDailyTotalConsumption()
    {
        var subject = claimsPrincipalUtil.GetNameIdentifier(User);
        var subjectUserMap = await userService.GetUser(subject);
        var milliliters = consumptionService.GetDailyTotalConsumption(subjectUserMap.User);

        return Ok(milliliters);
    }

    [Authorize]
    [HttpPost("log")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ConsumptionDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> LogConsumption(MillilitersDto millilitersDto)
    {
        try
        {
            var subject = claimsPrincipalUtil.GetNameIdentifier(User);
            var subjectUserMap = await userService.GetUser(subject);
            var consumption = await consumptionService.LogConsumption(subjectUserMap.User, millilitersDto);

            return Created("", consumption.ToDto());
        }
        catch (InvalidMillilitersException)
        {
            return BadRequest();
        }
    }
}