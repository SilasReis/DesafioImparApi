using Domain.Interfaces.Repository;
using Impar.Infra.Data.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryCar : RepositoryGenerics<Car>, ICarRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public RepositoryCar(DbContextOptions<ContextBase> optionsBuilder) : base(optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }


    }
}
