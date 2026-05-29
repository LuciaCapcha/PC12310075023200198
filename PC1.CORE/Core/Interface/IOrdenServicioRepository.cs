using System.Collections.Generic;
using System.Threading.Tasks;
using PC1.CORE.Core.Entities;

namespace PC1.CORE.Core.Interface
{
    public interface IOrdenServicioRepository
    {
        Task<IEnumerable<OrdenServicio>> GetAllAsync();
        Task<OrdenServicio?> GetByIdAsync(int id);
        Task<OrdenServicio> AddAsync(OrdenServicio orden);
        Task<bool> UpdateAsync(OrdenServicio orden);
        Task<bool> DeleteAsync(int id);
    }
}
