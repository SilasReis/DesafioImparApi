using AutoMapper;
using Domain.Dto;
using Domain.ViewModel;
using Impar.Infra.Data.Entities;

namespace Domain.AutoMapper
{
    public class PhotoMappingProfile : Profile
    {
        public PhotoMappingProfile()
        {
            PhotoAutoMapper();
            PhotoInsertAutoMapper();
        }

        public void PhotoAutoMapper()
        {
            CreateMap<PhotoDto, Photo>().ReverseMap();
        }

        public void PhotoInsertAutoMapper()
        {
            CreateMap<PhotoViewModel, Photo>().ReverseMap();
        }
    }
}
