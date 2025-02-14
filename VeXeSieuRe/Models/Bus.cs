using System.ComponentModel.DataAnnotations;

namespace VeXeSieuRe;

public enum BusOption { VIP, Normal }
public enum BusStatus { Busy, Available }
public class Bus: BaseEntity
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(10)]
    public string PlateNumber { get; set; }
    [Range(1, 50)]
    public int TotalSeats { get; set; }
    public BusOption Option { get; set; } //VIP, Normal
    public BusStatus Status { get; set; } //Busy, Available
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public Guid BusTypeId { get; set; }

    public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    public BusType BusType { get; set; } = default!;
    public ICollection<BusSeat> BusSeats { get; set; } = new List<BusSeat>();
}