using Microsoft.EntityFrameworkCore;
using Services.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.GenericService
{
    public class SvGenericRepository<T, TContext> : ISvGenericRepository<T>
        where T : class
        where TContext : DbContext
    {
        protected readonly TContext _context;
        protected readonly DbSet<T> _dbSet;

        public SvGenericRepository(TContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // Obtener todos los registros
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Obtener un registro por su ID
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Agregar un nuevo registro
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        // Eliminar un registro por su ID
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        // Guardar los cambios en la base de datos
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // Devuelve un IQueryable para consultas avanzadas
        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }
    }
}
