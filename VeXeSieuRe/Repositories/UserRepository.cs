using Microsoft.EntityFrameworkCore;

namespace VeXeSieuRe.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<bool> EmailExistsAsync(string email, Guid? excludeUserId = null);
}

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User?>> GetAllAsync()
    {
        return await _context.Users.Where(u => !u.DeletedAt.HasValue).ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users
            .SingleOrDefaultAsync(u => u.Id == id && !u.DeletedAt.HasValue);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .SingleOrDefaultAsync(u => u.Email == email && !u.DeletedAt.HasValue);
    }

    public async Task<bool> EmailExistsAsync(string email, Guid? excludeUserId = null)
    {
        return await _context.Users
            .AnyAsync(u => u.Email == email && u.Id != excludeUserId);
    }
}