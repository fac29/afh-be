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
            CreateMap<Collection, CollectionDto>()
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.CollectionMovies.Select(cm => cm.Movie)));
            CreateMap<AddCollectionDto, Collection>()
            .ForMember(dest => dest.CollectionMovies, opt => opt.MapFrom(src => src.CollectionMovies.Select(m => new CollectionMovie { MovieID = m.MovieID })))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
