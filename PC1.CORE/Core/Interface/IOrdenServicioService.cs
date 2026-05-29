using System.Collections.Generic;
using System.Threading.Tasks;
using PC1.CORE.Core.DTOs;

namespace PC1.CORE.Core.Interface
{
    public interface IOrdenServicioService
    {
        Task<IEnumerable<OrdenServicioDto>> GetAllAsync();
        Task<OrdenServicioDto?> GetByIdAsync(int id);
        Task<OrdenServicioDto> CreateAsync(OrdenServicioDto dto);
        Task<bool> UpdateAsync(OrdenServicioDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
