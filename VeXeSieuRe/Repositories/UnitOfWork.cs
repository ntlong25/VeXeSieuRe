namespace VeXeSieuRe.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    // them cac repository khac o day
    Task<bool> SaveChangesAsync();
}
public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public IUserRepository Users { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Users = new UserRepository(_context);
    }

    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;

    public void Dispose()
    {
        _context.Dispose();
    }
}