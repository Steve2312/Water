using Water.API.DTOs;
using Water.DAL.Models;

namespace Water.API.Repositories.Interfaces;

public interface IConsumptionRepository
{
    Task<Consumption> LogConsumption(User user, MillilitersDto millilitersDto);
}