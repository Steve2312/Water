using Water.DAL.Enums;
using Water.DAL.Models;

namespace Water.API.DTOs;

public class UserDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required double Weight { get; init; }
    public required Gender Gender { get; init; }
    
    public IEnumerable<ConsumptionDto>? Consumptions { get; init; }
}

public static class UserDtoExtensions
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Weight = user.Weight,
            Gender = user.Gender,
            Consumptions = user.Consumptions?.Select(consumption => consumption.ToDto())
        };
    }
}