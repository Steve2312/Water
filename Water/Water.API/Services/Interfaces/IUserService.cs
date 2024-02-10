using Water.API.DTOs;
using Water.DAL.Models;

namespace Water.API.Services.Interfaces;

public interface IUserService
{
    Task<SubjectUserMap> GetUser(string subject);
    Task<SubjectUserMap> RegisterUser(string subject, RegisterUserDto registerUserDto);
}