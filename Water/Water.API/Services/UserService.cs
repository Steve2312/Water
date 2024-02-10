using Water.API.DTOs;
using Water.API.Exceptions;
using Water.API.Repositories.Interfaces;
using Water.API.Services.Interfaces;
using Water.DAL.Models;

namespace Water.API.Services;

public class UserService(IUserRepository userRepository, ISubjectUserMapRepository subjectUserMapRepository): IUserService
{
    public async Task<SubjectUserMap> GetUser(string subject)
    {
        var subjectUserMap = await subjectUserMapRepository.GetMap(subject);
        
        if (subjectUserMap == null) throw new UserNotFoundException();

        return subjectUserMap;
    }

    public async Task<SubjectUserMap> RegisterUser(string subject, RegisterUserDto registerUserDto)
    {
        if (await subjectUserMapRepository.GetMap(subject) != null) throw new UserAlreadyRegisteredException();
        
        var user = await userRepository.Register(registerUserDto);
        var subjectUserMap = await subjectUserMapRepository.CreateMap(subject, user);

        return subjectUserMap;
    }
}