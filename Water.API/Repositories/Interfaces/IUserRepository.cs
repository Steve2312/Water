using Water.API.DTOs;
using Water.DAL.Models;

namespace Water.API.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> Register(RegisterUserDto registerUserDto);
}