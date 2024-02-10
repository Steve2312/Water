using Water.DAL.Enums;

namespace Water.DAL.Models;

public class User
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required double Weight { get; init; }
    public required Gender Gender { get; init; }

    public IEnumerable<Consumption> Consumptions { get; init; } = new List<Consumption>();
}