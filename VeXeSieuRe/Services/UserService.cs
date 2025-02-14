using AutoMapper;
using Microsoft.AspNetCore.Identity;
using VeXeSieuRe.Helpers;
using VeXeSieuRe.Repositories;
using VeXeSieuRe.Request;
using VeXeSieuRe.Response;

namespace VeXeSieuRe.Services;

public interface IUserService
{
    Task<IEnumerable<UserResponse>> GetAllUsers();
    Task<UserResponse?> GetUserByIdAsync(Guid id);
    Task<UserResponse?> GetUserByEmailAsync(string email);
    Task<UserResponse> CreateUserAsync(CreateUserRequest userRequest);
    Task<UserResponse> UpdateUserAsync(Guid userId, UpdateUserRequest request);
    Task DeleteUserAsync(Guid id);
}

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<CreateUserRequest> _passwordHasher;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IPasswordHasher<CreateUserRequest> passwordHasher, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponse>> GetAllUsers()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        return _mapper.Map<IEnumerable<UserResponse>>(users);
    }
    public async Task<UserResponse?> GetUserByIdAsync(Guid id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        return _mapper.Map<UserResponse>(user);
    }

    public async Task<UserResponse?> GetUserByEmailAsync(string email)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(email);
        return _mapper.Map<UserResponse>(user);
    }

    public async Task<UserResponse> CreateUserAsync(CreateUserRequest userRequest)
    {
        if (await _unitOfWork.Users.EmailExistsAsync(userRequest.Email))
            throw new ValidationException("Email already exists.");

        var user = new User
        {
            Fullname = userRequest.Fullname,
            DOB = userRequest.DOB,
            Email = userRequest.Email,
            Phone = userRequest.Phone,
            PasswordHash = _passwordHasher.HashPassword(userRequest, userRequest.Password)
        };
        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<UserResponse>(user);
    }

    public async Task<UserResponse> UpdateUserAsync(Guid userId, UpdateUserRequest request)
    {
        // 1. Validate input
        if (request == null) 
            throw new ValidationException("Request body is required");

        // 2. Get existing user
        var user = await _unitOfWork.Users.GetByIdAsync(userId) 
                   ?? throw new NotFoundException("User not found");

        // 3. Apply updates
        if (!string.IsNullOrEmpty(request.Fullname)) 
            user.Fullname = request.Fullname;

        if (!string.IsNullOrEmpty(request.Email))
        {
            if (await _unitOfWork.Users.EmailExistsAsync(request.Email, userId))
                throw new ValidationException("Email already exists");
                
            user.Email = request.Email;
        }

        if (!string.IsNullOrEmpty(request.Phone))
            user.Phone = request.Phone;

        // 4. Save changes
        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<UserResponse>(user);
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id) 
                   ?? throw new NotFoundException("User not found");
        user.DeletedAt = DateTime.UtcNow;
        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync();
        
    }
}