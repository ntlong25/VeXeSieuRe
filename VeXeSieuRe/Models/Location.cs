namespace VeXeSieuRe;

public enum LocationType { Hub, Stop }
public enum LocationStatus { Maintenance, Available}
public class Location: BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public LocationType Type { get; set; }
    public LocationStatus Status { get; set; }

    public ICollection<RouteStop> RouteStops { get; set; } = new List<RouteStop>();
    public ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
}