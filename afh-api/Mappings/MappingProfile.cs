using AutoMapper;
using afh_shared.DTOs;
using afh_db.Models;

namespace afh_api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<EditUserDto, User>();
            CreateMap<Movie, MovieDto>();
            CreateMap<AddMovieDto, Movie>();
        }
    }
}
