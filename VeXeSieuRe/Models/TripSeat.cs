namespace VeXeSieuRe;

public enum TripSeatStatus { AVAILABLE, BOOKED, LOCKED }
public class TripSeat: BaseEntity
{
    public Guid Id { get; set; }
    public Guid TripId { get; set; }
    public Guid SeatId { get; set; }
    public TripSeatStatus Status { get; set; } //AVAILABLE/BOOKED/LOCKED
    public Guid? BookingDetailId { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

    public Trip Trip { get; set; } = default!;
    public BusSeat BusSeat { get; set; } = default!;
    public BookingDetail? BookingDetail { get; set; } = default!;
}