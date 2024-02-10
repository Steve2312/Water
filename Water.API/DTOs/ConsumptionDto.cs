using Water.DAL.Models;

namespace Water.API.DTOs;

public class ConsumptionDto
{
    public required Guid Id { get; init; }
    public required int Milliliters { get; init; }
    public required DateTime Timestamp { get; init; }
}

public static class ConsumptionDtoExtensions
{
    public static ConsumptionDto ToDto(this Consumption consumption)
    {
        return new ConsumptionDto
        {
            Id = consumption.Id,
            Milliliters = consumption.Milliliters,
            Timestamp = consumption.Timestamp
        };
    }
}