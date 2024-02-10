using Water.API.DTOs;
using Water.DAL.Models;

namespace Water.API.Services.Interfaces;

public interface IConsumptionService
{
    MillilitersDto GetDailyRecommendedConsumption(User user);
    MillilitersDto GetDailyTotalConsumption(User user);
    Task<Consumption> LogConsumption(User user, MillilitersDto millilitersDto);
}