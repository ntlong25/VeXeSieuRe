namespace VeXeSieuRe.Response;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Fullname { get; set; }
    public DateTime DOB { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Role Role { get; set; }
    public string Status { get; set; }
    public DateTime CreateAt { get; set; }
}