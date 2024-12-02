using Domain.Dto;
using Domain.ViewModel;

namespace Domain.Interfaces.Services
{
    public interface ICarService
    {
        Task<bool> Add(CarViewModel car);
        Task<bool> Update(CarDto car);
        Task<List<CarDto>> List(int page, int itens);
        Task<CarDto?> FindById(long Id);
        Task<bool> Delete(long Id);
    }
}
