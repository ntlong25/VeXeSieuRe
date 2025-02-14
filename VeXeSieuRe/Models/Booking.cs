using System.ComponentModel.DataAnnotations;

namespace VeXeSieuRe;

public enum BookingStatus { Confirmed, Cancelled }
public class Booking: BaseEntity
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(15)]
    public string BookingCode { get; set; }
    [Range(0, double.MaxValue)]
    public decimal TotalAmount { get; set; }
    public PaymentStatus PaymentStatus { get; set; } //Paid, Pending, Failed
    public BookingStatus BookingStatus { get; set; } //Confirmed, Cancelled
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public Guid TripId { get; set; }
    public Guid UserId { get; set; }

    public User User { get; set; } = default!;
    public Trip Trip { get; set; } = default!;

    public ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
    public Payment? Payment { get; set; }
    public Review? Review { get; set; }
}