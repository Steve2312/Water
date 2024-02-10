using Water.API.DTOs;
using Water.API.Repositories.Interfaces;
using Water.DAL;
using Water.DAL.Models;

namespace Water.API.Repositories;

public class UserRepository(WaterDbContext context) : IUserRepository
{
    public async Task<User> Register(RegisterUserDto registerUserDto)
    {
        var user = registerUserDto.ToModel();

        context.Users.Add(user);

        await context.SaveChangesAsync();

        return user;
    }
}