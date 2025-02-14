using System.ComponentModel.DataAnnotations;

namespace VeXeSieuRe.Request;

public class UpdateUserRequest
{
    [Required]
    [StringLength(100, ErrorMessage = "Fullname cannot exceed 100 characters")]
    public string? Fullname { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "Invalid phone number format")]
    public string? Phone { get; set; }
}