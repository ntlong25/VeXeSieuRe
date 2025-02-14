namespace VeXeSieuRe;

public class RouteStop: BaseEntity
{
    public Guid RouteId { get; set; }
    public Guid LocationId { get; set; }
    public int StopOrder { get; set; } //thứ tự dừng
    public TimeSpan EstimatedTime { get; set; } //thời gian dừng

    public Route Route { get; set; } = default!;
    public Location Location { get; set; } = default!;
}