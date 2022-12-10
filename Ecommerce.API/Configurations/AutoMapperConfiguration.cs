using AutoMapper;
using Ecommerce.DOMAIN.DTOs.Request;
using Ecommerce.DOMAIN.DTOs.Response;
using Ecommerce.DOMAIN.Models;

namespace Ecommerce.API.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<UserCreationRequest, User>();
            CreateMap<UserUpdateRequest, User>();
            CreateMap<User, UserResponse>();
            
        }
    }
}
