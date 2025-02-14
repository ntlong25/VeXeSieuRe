using System.ComponentModel.DataAnnotations;

namespace VeXeSieuRe;

public enum BusSeatStatus { Available, Booked, Maintenance }
public class BusSeat: BaseEntity
{
    public Guid Id { get; set; }
    [Range(1, 50)]
    public int SeatNumber { get; set; }
    [Range(1, 2)]
    public int Floor { get; set; }
    public BusSeatStatus Status { get; set; }

    public Guid BusId { get; set; }
    
    public Bus Bus { get; set; } = default!;
    
    public ICollection<TripSeat> TripSeats { get; set; } = new List<TripSeat>();
}