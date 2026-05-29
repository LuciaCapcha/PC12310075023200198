using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PC1.CORE.Core.Entities;
using PC1.CORE.Core.Interface;
using PC1.CORE.Infrastructure.Data;

namespace PC1.CORE.Infrastructure.Repositories
{
    public class OrdenServicioRepository : IOrdenServicioRepository
    {
        private readonly TallerMecanicoDbContext _context;

        public OrdenServicioRepository(TallerMecanicoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrdenServicio>> GetAllAsync()
        {
            return await _context.OrdenServicios.AsNoTracking().ToListAsync();
        }

        public async Task<OrdenServicio?> GetByIdAsync(int id)
        {
            return await _context.OrdenServicios.FindAsync(id);
        }

        public async Task<OrdenServicio> AddAsync(OrdenServicio orden)
        {
            var entry = await _context.OrdenServicios.AddAsync(orden);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> UpdateAsync(OrdenServicio orden)
        {
            var exists = await _context.OrdenServicios.AnyAsync(o => o.Id == orden.Id);
            if (!exists) return false;
            _context.OrdenServicios.Update(orden);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.OrdenServicios.FindAsync(id);
            if (entity == null) return false;
            _context.OrdenServicios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
