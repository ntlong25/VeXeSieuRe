namespace VeXeSieuRe;

public abstract class BaseEntity
{
    public DateTime? DeletedAt { get; set; } = null;
    public bool IsDeleted => DeletedAt.HasValue;
}