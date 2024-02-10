using Water.API.DTOs;
using Water.API.Exceptions;
using Water.API.Repositories;
using Water.API.Repositories.Interfaces;
using Water.API.Services.Interfaces;
using Water.DAL.Models;

namespace Water.API.Services;

public class ConsumptionService(IConsumptionRepository consumptionRepository): IConsumptionService
{
    public MillilitersDto GetDailyRecommendedConsumption(User user)
    {
        return new MillilitersDto()
        {
            Milliliters = Convert.ToInt32(user.Weight * 30)
        };
    }

    public MillilitersDto GetDailyTotalConsumption(User user)
    {
        var milliliters = user.Consumptions
            .Where(consumption => consumption.Timestamp.Date == DateTime.Today)
            .Sum(consumption => consumption.Milliliters);

        return new MillilitersDto()
        {
            Milliliters = milliliters
        };
    }

    public Task<Consumption> LogConsumption(User user, MillilitersDto millilitersDto)
    {
        if (millilitersDto.Milliliters <= 0) throw new InvalidMillilitersException();
        
        return consumptionRepository.LogConsumption(user, millilitersDto);
    }
}