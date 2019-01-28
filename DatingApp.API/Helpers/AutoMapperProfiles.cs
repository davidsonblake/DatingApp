using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(x => x.PhotoUrl, opt => {
                    opt.MapFrom(source => source.Photos.FirstOrDefault(p => p.IsMain).Url);
                 })
                 .ForMember(dest => dest.Age, opt => {
                     opt.MapFrom((s, d) =>  s.DateOfBirth.CalculateAge());
                 });
            CreateMap<User, UserForDetailDto>()                
                .ForMember(x => x.PhotoUrl, opt => {
                    opt.MapFrom(source => source.Photos.FirstOrDefault(p => p.IsMain).Url);
                 })
                 .ForMember(dest => dest.Age, opt => {
                     opt.MapFrom((s, d) =>  s.DateOfBirth.CalculateAge());
                 });
            CreateMap<Photo, PhotosForDetailsDto>();
        }
    }
}