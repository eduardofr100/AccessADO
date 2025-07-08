using Api_DataAccess_ADO.Models.Entities;

namespace Api_DataAccess_ADO.Repositories.Interfaces
{
    public interface IVentaRepository
    {
        Task<bool> CreateVenta(Venta venta);
        Task<IEnumerable<Venta>> GetAllVenta();
        Task<Venta> GetByIdVenta(int id);
        Task<bool> UpdateVenta(Venta venta);
        Task<bool> DeleteVenta(int id);
    }
}
