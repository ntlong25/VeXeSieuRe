namespace VeXeSieuRe;

public class Route: BaseEntity
{
    public Guid Id { get; set; }
    public decimal Distance { get; set; }
    public TimeSpan EstimatedTime { get; set; }
    public string Status { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public Guid DepartureLocationId { get; set; }
    public Guid ArrivalLocationId { get; set; }

    public Location DepartureLocation { get; set; } = default!;
    public Location ArrivalLocation { get; set; } = default!;
    public ICollection<RouteStop> RouteStops { get; set; } = new List<RouteStop>();
    public ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
