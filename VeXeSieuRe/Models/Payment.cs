using System.ComponentModel.DataAnnotations;

namespace VeXeSieuRe;

public enum PaymentStatus { Paid, Pending, Failed }
public enum PaymentMethod { Momo, VnPay, Banking, Cash }
public class Payment: BaseEntity
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; } //MOMO/VNPAY/BANKING/CASH
    [Required]
    public string TransactionCode { get; set; }
    public PaymentStatus Status { get; set; } //PENDING/SUCCESS/FAILED
    public DateTime PaidAt { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid BookingId { get; set; }

    public Booking Booking { get; set; } = default!;

}