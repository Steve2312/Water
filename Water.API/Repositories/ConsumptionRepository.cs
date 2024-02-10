using Water.API.DTOs;
using Water.API.Repositories.Interfaces;
using Water.DAL;
using Water.DAL.Models;

namespace Water.API.Repositories;

public class ConsumptionRepository(WaterDbContext context): IConsumptionRepository
{
    public async Task<Consumption> LogConsumption(User user, MillilitersDto millilitersDto)
    {
        var consumption = new Consumption
        {
            Milliliters = millilitersDto.Milliliters,
            Timestamp = DateTime.Now,
            User = user
        };

        context.Consumptions.Add(consumption);

        await context.SaveChangesAsync();

        return consumption;
    }
}