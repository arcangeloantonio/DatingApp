using System.Linq;
using AutoMapper;
using DatingApp.API.DTOs;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Entity to DTO
            CreateMap<User, UserForListDTO>().ForMember(dest => dest.PhotoURL, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            }).ForMember(dest => dest.Age, opt => {
                opt.MapFrom(d => d.DateOfBirth.CalculateAge());
            });
            CreateMap<User, UserForDetailedDTO>().ForMember(dest => dest.PhotoURL, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            }).ForMember(dest => dest.Age, opt => {
                opt.MapFrom(d => d.DateOfBirth.CalculateAge());
            });
            CreateMap<Photo, PhotosForDetailedDTO>();
            CreateMap<Photo, PhotoForReturnDto>();

            //DTO to Entity
            CreateMap<UserForUpdateDto, User>();
            CreateMap<PhotoForCreationDto, Photo>();
        }
    }
}