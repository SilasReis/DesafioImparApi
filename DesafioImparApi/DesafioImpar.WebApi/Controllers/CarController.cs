using AutoMapper;
using Domain.Dto;
using Domain.Interfaces.Services;
using Domain.ViewModel;
using Impar.Infra.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioImpar.WebApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _serviceCar;

        public CarController(ICarService serviceCar)
        {
            _serviceCar = serviceCar;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<bool> Add(CarViewModel car)
        {
            return await _serviceCar.Add(car);
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<bool> Update(CarDto car)
        {
           return await _serviceCar.Update(car);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<CarDto>> Get([FromQuery] int page, int itens)
        {
            return await _serviceCar.List(page, itens);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<CarDto?> GetById(long id)
        {
            return await _serviceCar.FindById(id);
        }

        [HttpGet("GetByName/{name}")]
        [AllowAnonymous]
        public async Task<List<CarDto>> GetByName(string name)
        {
            return await _serviceCar.ListByName(name);
        }

        [HttpDelete]
        [AllowAnonymous]
        public async Task<bool> Delete([FromQuery] long id)
        {
            return await _serviceCar.Delete(id);
        }
    }
}
