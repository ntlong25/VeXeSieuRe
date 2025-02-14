using System.ComponentModel.DataAnnotations;

namespace VeXeSieuRe.Request;

public class CreateUserRequest
{
    [Required]
    public string Fullname { get; set; }
    [Required]
    public DateTime DOB { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }
    [Required]
    [Phone(ErrorMessage = "Invalid phone number format")]
    public string Phone { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}