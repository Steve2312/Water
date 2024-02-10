using Water.DAL.Models;

namespace Water.API.Repositories.Interfaces;

public interface ISubjectUserMapRepository
{
    Task<SubjectUserMap?> GetMap(string subject);
    Task<SubjectUserMap> CreateMap(string subject, User user);
}