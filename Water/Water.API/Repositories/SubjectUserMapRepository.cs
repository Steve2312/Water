using Microsoft.EntityFrameworkCore;
using Water.API.Repositories.Interfaces;
using Water.DAL;
using Water.DAL.Models;

namespace Water.API.Repositories;

public class SubjectUserMapRepository(WaterDbContext context): ISubjectUserMapRepository
{
    public async Task<SubjectUserMap?> GetMap(string subject)
    {
        return await context.SubjectUserMaps
            .Include(map => map.User)
            .Include(map => map.User.Consumptions)
            .SingleOrDefaultAsync(map => map.Subject == subject);
    }

    public async Task<SubjectUserMap> CreateMap(string subject, User user)
    {
        var subjectUserMap = new SubjectUserMap
        {
            Subject = subject,
            User = user
        };

        context.SubjectUserMaps.Add(subjectUserMap);

        await context.SaveChangesAsync();

        return subjectUserMap;
    }
}