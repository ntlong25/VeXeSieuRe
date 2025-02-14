namespace VeXeSieuRe;

public class BookingDetail: BaseEntity
{
    public Guid Id { get; set; }
    public string SeatNumber { get; set; } //e.g., A1, A2
    public string PassengerName { get; set; } = string.Empty;
    public string PassengerPhone { get; set; } = string.Empty;
    public string? Note { get; set; }
    
    public Guid BusSeatId { get; set; }
    public Guid BookingId { get; set; }
    public Guid TripId { get; set; }
    public Guid PickupLocationId { get; set; }
    public Guid DropoffLocationId { get; set; }

    public Booking Booking { get; set; } = default!;
    public Location PickupLocation { get; set; } = default!;
    public Location DropoffLocation { get; set; } = default!;
    public TripSeat TripSeat { get; set; } = default!;
    public BusSeat BusSeat { get; set; } = default!;
}