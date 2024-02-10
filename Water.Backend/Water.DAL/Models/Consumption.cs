namespace Water.DAL.Models;

public class Consumption
{
    public Guid Id { get; init; }
    public required int Milliliters { get; init; }
    public required DateTime Timestamp { get; init; }
    
    public required User User { get; init; }
}