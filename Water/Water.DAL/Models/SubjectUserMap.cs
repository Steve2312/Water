namespace Water.DAL.Models;

public class SubjectUserMap
{
    public required string Subject { get; init; }
    
    public required User User { get; init; }
}