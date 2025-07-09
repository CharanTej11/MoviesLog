using AutoMapper;
using MoviesLog.DTOs;
using MoviesLog.Models;

namespace MoviesLog.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Director, DirectorDto>().ReverseMap();
            CreateMap<DirectorCreateDto, Director>();

            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<MovieCreateDto, Movie>();

            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<ReviewCreateDto, Review>();
        }
    }
}
