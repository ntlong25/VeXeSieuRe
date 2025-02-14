using System.ComponentModel.DataAnnotations;

namespace VeXeSieuRe;

public class Review: BaseEntity
{
    public Guid Id { get; set; }
    [Range(1, 5)]
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid BookingId { get; set; }
    public Guid UserId { get; set; }

    public User User { get; set; } = default!;
}