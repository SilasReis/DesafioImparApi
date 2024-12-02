using AutoMapper;
using Domain.Dto;
using Domain.ViewModel;
using Impar.Infra.Data.Entities;

namespace Domain.AutoMapper
{
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile()
        {
            CarAutoMapper();
            CarInsertAutoMapper();
        }

        public void CarAutoMapper()
        {
            CreateMap<CarDto, Car>().ReverseMap();
        }

        public void CarInsertAutoMapper()
        {
            CreateMap<CarViewModel, Car>().ReverseMap();
        }
    }
}
