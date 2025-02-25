namespace VeXeSieuRe;

public class BusType: BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public ICollection<Bus> Buses { get; set; } = new List<Bus>();
}