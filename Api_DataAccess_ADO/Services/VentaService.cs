using Api_DataAccess_ADO.Models.Entities;
using Api_DataAccess_ADO.Repositories.Interfaces;

namespace Api_DataAccess_ADO.Services
{
    public class VentaService
    {
        private readonly IVentaRepository _ventaRepository;

        public VentaService(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public async Task<bool> CreateVenta(Venta venta)
        {
            return await _ventaRepository.CreateVenta(venta);
        }

        public async Task<bool> UpdateVenta(Venta venta)
        {
            return await _ventaRepository.UpdateVenta(venta);
        }

        public async Task<bool> DeleteVenta(int id)
        {
            return await _ventaRepository.DeleteVenta(id);
        }

        public async Task<Venta> GetByIdVenta(int id)
        {
            return await _ventaRepository.GetByIdVenta(id);
        }

        public async Task<IEnumerable<Venta>> GetAllVenta()
        {
            return await _ventaRepository.GetAllVenta();
        }
    }
}
