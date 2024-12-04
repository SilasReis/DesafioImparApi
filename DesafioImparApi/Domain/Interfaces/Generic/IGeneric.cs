using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generic
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T Objeto);
        Task Update(T Objeto);
        Task Delete(T Objeto);
        Task<List<T>> List(int Page, int Itens);
        Task<T?> GetEntityById(long id);
        Task<List<T>> ListByName(string name);
    }
}
