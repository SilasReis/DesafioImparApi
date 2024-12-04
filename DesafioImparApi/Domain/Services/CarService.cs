using AutoMapper;
using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.ViewModel;
using Impar.Infra.Data.Entities;

namespace Domain.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(CarViewModel car)
        {
            await _carRepository.Add(_mapper.Map<Car>(car));

            return true;
        }

        public async Task<bool> Delete(long Id)
        {
            Car? car = await _carRepository.GetEntityById(Id);

            if (car != null)
            {
                await _carRepository.Delete(car);
                return true;
            }
            else
                return false;
        }

        public async Task<CarDto?> FindById(long Id)
        {
            return _mapper.Map<CarDto?>(await _carRepository.GetEntityById(Id));
        }

        public async Task<List<CarDto>> List(int page, int itens)
        {
            return _mapper.Map<List<CarDto>>(await _carRepository.List(page, itens));
        }

        public async Task<List<CarDto>> ListByName(string name) 
        {
            return _mapper.Map<List<CarDto>>(await _carRepository.ListByName(name));
        }

        public async Task<bool> Update(CarDto car)
        {
            Car? carro = await _carRepository.GetEntityById(car.Id);

            if (car != null)
            {
                await _carRepository.Update(_mapper.Map<Car>(car));
                return true;
            }
            else
                return false;
        }
    }
}
