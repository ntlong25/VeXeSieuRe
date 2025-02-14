namespace VeXeSieuRe;

public class Trip: BaseEntity
{
    public Guid Id { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

    public Guid RouteId { get; set; }
    public Guid BusId { get; set; }
    public Guid DriverId { get; set; }

    public Route Route { get; set; } = default!;
    public Bus Bus { get; set; } = default!;
    public User? Driver { get; set; }

    public ICollection<TripSeat> TripSeats { get; set; } = new List<TripSeat>();
}