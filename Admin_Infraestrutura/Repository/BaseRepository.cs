using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Admin_Dominio.Interfaces.IRepositories;
using Admin_Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin_Infraestrutura.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _db;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await _db.AsNoTracking().ToListAsync();
        }

        public async Task<T> ObterPorId(int id)
        {
            return await _db.FindAsync(id);
        }

        public async Task<IEnumerable<T>> Consultar(Expression<Func<T, bool>> predicate)
        {
            return await _db.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task Inserir(T entities)
        {
           await _db.AddAsync(entities);
           await SaveChangesAsync();
        }

        public async Task Alterar(T entities)
        {
            _db.Update(entities);
            await SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var entity = await ObterPorId(id);
            _db.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();//Será desfeita a conexão somente se ela não for null
        }
    }
}