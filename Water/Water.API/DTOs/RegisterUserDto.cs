using Water.DAL.Enums;
using Water.DAL.Models;

namespace Water.API.DTOs;

public class RegisterUserDto
{
    public required string Name { get; init; }
    public required double Weight { get; init; }
    public required Gender Gender { get; init; }
}

public static class RegisterUserDtoExtensions
{
    public static User ToModel(this RegisterUserDto registerUserDto)
    {
        return new User
        {
            Name = registerUserDto.Name,
            Weight = registerUserDto.Weight,
            Gender = registerUserDto.Gender
        };
    }
}