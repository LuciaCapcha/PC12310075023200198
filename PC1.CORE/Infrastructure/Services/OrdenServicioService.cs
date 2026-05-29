using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC1.CORE.Core.DTOs;
using PC1.CORE.Core.Entities;
using PC1.CORE.Core.Interface;

namespace PC1.CORE.Infrastructure.Services
{
    public class OrdenServicioService : IOrdenServicioService
    {
        private readonly IOrdenServicioRepository _repository;

        public OrdenServicioService(IOrdenServicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrdenServicioDto> CreateAsync(OrdenServicioDto dto)
        {
            var entity = new OrdenServicio
            {
                FechaIngreso = dto.FechaIngreso,
                DescripcionProblema = dto.DescripcionProblema,
                CostoEstimado = dto.CostoEstimado,
                Estado = dto.Estado,
                VehiculoId = dto.VehiculoId,
                TipoServicioId = dto.TipoServicioId
            };

            var created = await _repository.AddAsync(entity);
            dto.Id = created.Id;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrdenServicioDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(o => new OrdenServicioDto
            {
                Id = o.Id,
                FechaIngreso = o.FechaIngreso,
                DescripcionProblema = o.DescripcionProblema,
                CostoEstimado = o.CostoEstimado,
                Estado = o.Estado,
                VehiculoId = o.VehiculoId,
                TipoServicioId = o.TipoServicioId
            });
        }

        public async Task<OrdenServicioDto?> GetByIdAsync(int id)
        {
            var o = await _repository.GetByIdAsync(id);
            if (o == null) return null;
            return new OrdenServicioDto
            {
                Id = o.Id,
                FechaIngreso = o.FechaIngreso,
                DescripcionProblema = o.DescripcionProblema,
                CostoEstimado = o.CostoEstimado,
                Estado = o.Estado,
                VehiculoId = o.VehiculoId,
                TipoServicioId = o.TipoServicioId
            };
        }

        public async Task<bool> UpdateAsync(OrdenServicioDto dto)
        {
            var entity = new OrdenServicio
            {
                Id = dto.Id,
                FechaIngreso = dto.FechaIngreso,
                DescripcionProblema = dto.DescripcionProblema,
                CostoEstimado = dto.CostoEstimado,
                Estado = dto.Estado,
                VehiculoId = dto.VehiculoId,
                TipoServicioId = dto.TipoServicioId
            };

            return await _repository.UpdateAsync(entity);
        }
    }
}
