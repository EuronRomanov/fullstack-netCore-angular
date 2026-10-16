using AutoMapper;
using server.Dto;
using server.Entities;

namespace server.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Image, ImageDtoRes>();

        }
    }

   
}
