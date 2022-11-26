using AutoMapper;
using Ecommerce.DOMAIN.DTOs.Request;
using Ecommerce.DOMAIN.Models;

namespace Ecommerce.API.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<User, RequestUserCreation>();
        }
    }
}
