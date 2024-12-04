using Domain.Interfaces.Generic;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Repository.Generic
{
    public class RepositoryGenerics<T> : IGeneric<T> where T : class
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public RepositoryGenerics(DbContextOptions<ContextBase> optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }

        public async Task Add(T Objeto)
        {
            using (ContextBase data = new ContextBase(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T objeto)
        {
            using var data = new ContextBase(_optionsBuilder);
            data.Set<T>().Attach(objeto);
            data.Set<T>().Remove(objeto);
            await data.SaveChangesAsync();
        }


        public async Task Update(T Objeto)
        {
            using ContextBase data = new(_optionsBuilder);
            data.Set<T>().Update(Objeto);
            await data.SaveChangesAsync();
        }

        public async Task<T?> GetEntityById(long id)
        {
            using ContextBase data = new(_optionsBuilder);

            var query = data.Set<T>().AsQueryable();
            var entityType = data.Model.FindEntityType(typeof(T));
            if (entityType != null)
            {
                foreach (var navigation in entityType.GetNavigations())
                {
                    query = query.Include(navigation.Name);
                }
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<long>(e, "Id") == id);
        }


        public async Task<List<T>> ListByName(string name)
        {
            using var data = new ContextBase(_optionsBuilder);

            var query = data.Set<T>().AsQueryable();

            var entityType = data.Model.FindEntityType(typeof(T));
            if (entityType != null)
            {
                foreach (var navigation in entityType.GetNavigations())
                {
                    query = query.Include(navigation.Name);
                }
            }

            return await query
                .Where(e => EF.Property<string>(e, "Name").Contains(name))
                .ToListAsync();
        }

        public async Task<List<T>> List(int page, int itens)
        {
            using ContextBase data = new(_optionsBuilder);

            var query = data.Set<T>().AsQueryable();
            var entityType = data.Model.FindEntityType(typeof(T));
            if (entityType != null)
            {
                foreach (var navigation in entityType.GetNavigations())
                {
                    query = query.Include(navigation.Name);
                }
            }

            return await query
                .Skip((page - 1) * itens)
                .Take(itens)
                .ToListAsync();
        }

    }
}
