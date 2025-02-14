using AutoMapper;
using VeXeSieuRe.Response;

namespace VeXeSieuRe.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserResponse>();
    }
}