using System.ComponentModel.DataAnnotations;

namespace VeXeSieuRe;

public enum Role { Admin, Customer, Driver }
public class User: BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Fullname { get; set; }
    [DataType(DataType.Date)]
    public DateTime? DOB { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string? Phone { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
    public string? Status { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<Trip>? DriveTrips { get; set; }
}